import readTxtToPoints as read
from polynom import *
from graph_print import *

pointTable = read.readTable("./d.txt")
monotone = getTypeOfMonotone(pointTable)
pointTable.sort(key=lambda point: point.x)

read.printTable(pointTable)

x = float(input("Введите x: "))
n = int(input("Введите n: "))

index = getIndex(pointTable, x)
newPointTable = getWorkingPoints(pointTable, index, n + 1)
subsNewton = NewtonMethod(newPointTable)
subsHermit = HermitMethod(newPointTable)
print("Newton:")
printSubTable(subsNewton)
print("Hermit:")
printSubTable(subsHermit)

print("Newton: {:.6f}".format(calcApproximateValue(subsNewton, n, x)))
# pp = pointTable.copy()
# for i in range(len(pp)):
#     pp[i].y = calcApproximateValue(subsNewton, n, pp[i].x)
# plot_graph(pp)


print("Hermit: {:.6f}".format(calcApproximateValue(subsHermit, n, x)))

print("Root by Newton: {:.6f}".format(rootByNewton(pointTable, n, 0)))
print("Root by Hermit: {:.6f}".format(rootByHermit(pointTable, n, 0)))

x, y = systemRoot()
print(f"System root:\nx = {x}\ny = {y}\n")


