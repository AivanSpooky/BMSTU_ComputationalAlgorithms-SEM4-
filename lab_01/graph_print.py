import matplotlib.pyplot as plt
from pointClass import *

def plot_graph(points):
    x_values = [point.x for point in points]
    y_values = [point.y for point in points]

    plt.plot(x_values, y_values)
    plt.xlabel('X')
    plt.ylabel('Y')
    plt.title('График функции')
    plt.grid(True)
    plt.show()