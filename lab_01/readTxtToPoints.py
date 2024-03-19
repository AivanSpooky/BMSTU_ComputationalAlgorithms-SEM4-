from pointClass import *


def readTable(name):
    pointTable = []
    file = open(name)
    next(file)
    for line in file.readlines():
        row = list(map(float, line.split(" ")))
        if len(row) == 2:
            pointTable.append(Point(row[0], row[1], 0, 0))
        else:
            pointTable.append(Point(row[0], row[1], row[2], row[3]))
    file.close()
    return pointTable

def readSystemTable(name, number):
    pointTable = []
    file = open(name)
    next(file)
    for line in file.readlines():
        row = list(map(float, line.split(" ")))
        if number == 1:
            pointTable.append([Point(row[0], row[1], 0, 0), None])
        else:
            pointTable.append([Point(row[0], None, 0, 0), row[1]])
    file.close()
    return pointTable


def printTable(pointTable):
    print("+" + "-" * 7 + ("+" + "-" * 12) * 4 + "+")
    print("| {:^5s} | {:^10s} | {:^10s} | {:^10s} | {:^10s} |".format("№", "X", "Y", "Y\'", "Y\'\'"))
    print("+" + "-" * 7 + ("+" + "-" * 12) * 4 + "+")
    for i in range(len(pointTable)):
        print("| {:^5d} | {:^10.3f} | {:^10.3f} | {:^10.3f} | {:^10.3f} |".format(i,
                                                            pointTable[i].x,
                                                            pointTable[i].y,
                                                            pointTable[i].dx,
                                                            pointTable[i].ddx))
    print("+" + "-" * 7 + ("+" + "-" * 12) * 4 + "+")