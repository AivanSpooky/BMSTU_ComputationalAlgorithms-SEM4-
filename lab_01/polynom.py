import numpy as numpy
from pointClass import *
from readTxtToPoints import readSystemTable, readTable, printTable

notMonotone = 'notMonotone'
increasing = 'increasing'
decreasing = 'decreasing'


def getTypeOfMonotone(pointTable):
    isIncreasing = True
    isDecreasing = True
    for rowI in range(len(pointTable) - 1):
        if not (pointTable[rowI].x < pointTable[rowI + 1].x and pointTable[rowI].x < pointTable[rowI + 1].x):
            isIncreasing = False
    for rowI in range(len(pointTable) - 1):
        if not (pointTable[rowI].x > pointTable[rowI + 1].x and pointTable[rowI].x > pointTable[rowI + 1].x):
            isDecreasing = False
    if isIncreasing:
        return increasing
    if isDecreasing:
        return decreasing
    return notMonotone


def getIndex(points, x):
    dif = abs(points[0].x - x)
    index = 0
    for i in range(len(points)):
        if abs(points[i].x - x) < dif:
            dif = abs(points[i].x - x)
            index = i
    return index


def getWorkingPoints(points, index, n):
    left = index
    right = index
    for i in range(n - 1):
        if i % 2 == 0:
            if left == 0:
                right += 1
            else:
                left -= 1
        else:
            if right == len(points) - 1:
                left -= 1
            else:
                right += 1
    return points[left:right + 1]


def NewtonMethod(pointTable):
    countOfRowsOfTableData = 2
    tableOfSub = []
    [tableOfSub.append([point.x, point.y]) for point in pointTable]

    tableOfSub = list([list(row) for row in numpy.transpose(tableOfSub)])
    XRow = tableOfSub[0]
    # Добавление столбцов (строк в моей реализации)
    for countOfArgs in range(1, len(XRow)):
        tableOfSub.append([])
        curYRow = tableOfSub[len(tableOfSub) - countOfRowsOfTableData]
        # Добавление очередного элемента
        for j in range(0, len(XRow) - countOfArgs):
            cur = (curYRow[j] - curYRow[j + 1]) / (XRow[j] - XRow[j + countOfArgs])
            tableOfSub[countOfArgs + countOfRowsOfTableData - 1].append(cur)
    return tableOfSub


def calcApproximateValue(tableOfSub, n, x):
    countOfArgs = 2
    sum = tableOfSub[1][0]
    mainPart = 1
    for i in range(n):
        mainPart *= (x - tableOfSub[0][i])
        sum += mainPart * tableOfSub[i + countOfArgs][0]
    return sum


def HermitMethod(pointTable):
    countOfRowsOfTableData = 2
    tableOfSub = []
    [tableOfSub.append([point.x, point.y]) for point in pointTable]
    YdRow = []
    YddRow = []
    for point in pointTable:
        YdRow.append(point.dx)
        YdRow.append(point.dx)
        YdRow.append(None)
        YddRow.append(point.ddx/2)
        YddRow.append(None)
        YddRow.append(None)
    XColId = 0
    YColId = 1
    # Вставка пустых списком (будущих разностей) в 3 столбец
    for i in range(0, len(tableOfSub) * 3, 3):
        tableOfSub.insert(i + 1, [])
        tableOfSub.insert(i + 1, [])
    # Копирование точек
    for i in range(0, len(tableOfSub), 3):
        tableOfSub[i + 1].append(tableOfSub[i][XColId])
        tableOfSub[i + 1].append(tableOfSub[i][YColId])
        tableOfSub[i + 2].append(tableOfSub[i][XColId])
        tableOfSub[i + 2].append(tableOfSub[i][YColId])
    for i in range(0, len(tableOfSub) - 3, 3):
        subElement = (tableOfSub[i][YColId] - tableOfSub[i + 3][YColId]) / (tableOfSub[i][XColId] - tableOfSub[i + 3][XColId])
        # if not pointTable[i + 1].isExit:
        #     continue
        # else:
        YdRow[i + 2] = subElement
    for i in range(0, len(tableOfSub) - 3, 3):
        subElement = (YdRow[i] - YdRow[i + 2]) / (tableOfSub[i][XColId] - tableOfSub[i + 3][XColId])
        # if not pointTable[i + 1].isExit:
        #     continue
        # else:
        YddRow[i + 1] = subElement
        YddRow[i + 2] = subElement
    tableOfSub = list([list(row) for row in numpy.transpose(tableOfSub)])
    XRow = tableOfSub[0]
    YdRow.pop()
    YddRow.pop()
    YddRow.pop()
    tableOfSub.append(YdRow)
    tableOfSub.append(YddRow)

    # Добавление столбцов (строк в моей реализации)
    for countOfArgs in range(3, len(XRow)):
        tableOfSub.append([])
        curYRow = tableOfSub[len(tableOfSub) - countOfRowsOfTableData]
        # Добавление очередного элемента
        for j in range(0, len(XRow) - countOfArgs):
            if (abs(XRow[j] - XRow[j + countOfArgs]) < 1e-8):
                cur = YdRow[j]
            else:
                cur = (curYRow[j] - curYRow[j + 1]) / (XRow[j] - XRow[j + countOfArgs])
            tableOfSub[countOfArgs + countOfRowsOfTableData - 1].append(cur)
    # Удаление пустого списка
    return tableOfSub


def calcApproximateValue(tableOfSub, n, x):
    countOfArgs = 2
    sum = tableOfSub[1][0]
    mainPart = 1
    # print('N ',n)
    for i in range(n):
        mainPart *= (x - tableOfSub[0][i])
        sum += mainPart * tableOfSub[i + countOfArgs][0]
        # print("value", tableOfSub[i + countOfArgs][0])
        #print(i)
    return sum


def rootByNewton(pointTable, n, monotone=1):
    newTable = []
    # if monotone != notMonotone:
    #printTable(pointTable)
    for point in pointTable:
        newTable.append(Point(point.y, point.x, 0, 0))
    newTable.sort(key=lambda point: point.x)
    index = getIndex(newTable, 0)
    newTable = getWorkingPoints(newTable, index, n + 1)
    for point in newTable:
        point.x, point.y = point.y, point.x
    printTable(newTable)
    subs = NewtonMethod(newTable)
    if (monotone == 0):
        r = newTable[-1].x
        l = newTable[0].x
        #print(l, r)
        while r - l > 1e-6:
            m = (r + l) / 2
            #print(f"m = {m}")
            y = calcApproximateValue(subs, n, m)
            if y < 0:
                l = m
            else:
                r = m
    else:
        l = newTable[-1].x
        r = newTable[0].x
        #print(l, r)
        while r - l > 1e-6:
            m = (r + l) / 2
            #print(f"m = {m}")
            y = calcApproximateValue(subs, n, m)
            if y < 0:
                r = m
            else:
                l = m
    return l
    printSubTable(subs)
    return calcApproximateValue(subs, n, 0)
    # else:
    #     subs = NewtonMethod(pointTable)
    #     r = pointTable[-1].x
    #     l = pointTable[0].x
    #     while r - l > 1e-4:
    #         m = (r + l) / 2
    #         y = calcApproximateValue(subs, n, m)
    #         if y < 0:
    #             l = m
    #         else:
    #             r = m
    #     return l


def rootByHermit(pointTable, n, monotone):
    if monotone != 0:
        newTable = []
        for i in pointTable:
            if i.dx != 0:
                if i.ddx != 0:
                    newTable.append(Point(i.y, i.x, 1 / i.dx, i.ddx/(i.dx**3)))
                else:
                    newTable.append(Point(i.y, i.x, 1 / i.dx, 0))
            else:
                if i.ddx != 0:
                    p = Point(i.y, i.x, 0, - i.ddx/(i.dx**3))
                else:
                    p = Point(i.y, i.x, 0, 0)
                p.isExit = False
                newTable.append(p)
        newTable.sort(key=lambda point: point.x)
        subs = HermitMethod(newTable)
        return calcApproximateValue(subs, n, 0)
    else:
        tableOfSub = HermitMethod(pointTable)
        r = pointTable[-1].x
        l = pointTable[0].x
        i = 0
        while r - l > 1e-8:
            m = (r + l) / 2
            y = calcApproximateValue(tableOfSub, n, m)
            if y < 0:
                l = m
            else:
                r = m
            i += 1
        print(i)
        return l
    
def systemRoot():
    pointTable1 = readSystemTable("./system1.txt", 1)
    pointTable2 = readSystemTable("./system2.txt", 2)
    PT1 = readTable("./system1.txt")
    PT2 = readTable("./system2.txt")
    subsNewton1 = NewtonMethod(PT1)
    subsNewton2 = NewtonMethod(PT2)
    for i in range(len(pointTable1)):
        pointTable1[i][1] = calcApproximateValue(subsNewton2, len(pointTable2)-1, pointTable1[i][0].x)
        pointTable1[i][0].y = pointTable1[i][0].y - pointTable1[i][1]
    for i in range(len(pointTable2)):
        pointTable2[i][0].y = calcApproximateValue(subsNewton1, len(pointTable1)-1, pointTable2[i][0].x)
        pointTable2[i][0].y -= pointTable2[i][1]

    newPT = []
    for i in range(len(pointTable1)):
        newPT.append(pointTable1[i][0])
    for i in range(len(pointTable2)):
        newPT.append(pointTable2[i][0])
    
    printTable(newPT)
    n = 8
    res_x = rootByNewton(newPT, n, getTypeOfMonotone(newPT))
    return res_x, calcApproximateValue(subsNewton1, n, res_x)


def printSubTable(subTable):
    countArray = len(subTable)
    maxLen = len(subTable[0])
    print(("+" + "-" * 12) * countArray + "+")
    print("| {:^10s} | {:^10s}".format("X", "Y"), end=' ')
    for k in range(2, countArray):
        print("| {:^10s}".format("Y" + "("+str((k - 1))+ ")"), end=' ')
    print("|")
    print(("+" + "-" * 12) * countArray + "+")

    for i in range(maxLen):
        for j in range(countArray):
            if j >= countArray - i:
                print("| {:^10s}".format(" "), end=' ')
            else:
                print("| {:^10.3f}".format(subTable[j][i]), end=' ')
        print("|")

    print(("+" + "-" * 12) * countArray + "+")