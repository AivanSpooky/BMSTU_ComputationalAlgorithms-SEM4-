import numpy as np
from math import fabs
from matplotlib import pyplot as plt

ESP = 1e-6

x0 = 0
x1 = 1
y0 = 1
yN = 3
N = 1000
h = (x1 - x0) / N 

def cmp_with_esp(A):
    for i in range(len(A)):
        if fabs(A[i]) > ESP:
            return True
    return False

def init_Y():
    Y = list()
    for i in range(N + 1):
         Y.append(y0 + (yN - y0) / (x1 - x0) * i * h)
    return Y 

def sub_matrix(A, B):
    result = list()
    for i in range(len(A)):
        result.append(A[i] - B[i])
    return result

def solution():
    Y = init_Y()
    X = [x0 + i * h for i in range(N + 1)]
    delta_Y = init_Y()
    while cmp_with_esp(delta_Y):
        W = [[0 for _ in range(N + 1)] for __ in range(N + 1)]
        W[0][0] = 1
        W[N][N] = 1 

        for i in range(1, N):
            W[i][i - 1] = 1 
            W[i][i] = -2 - 3 * h * h * (Y[i] + X[i]**2)**2
            W[i][i + 1] = 1 

        F = [0 for _ in range(N + 1)]
        F[0] = Y[0] - y0
        F[N] = Y[N] - yN

        for i in range(1, N): 
            F[i] = Y[i - 1] - 2 * Y[i] + Y[i + 1] - h**2 * (Y[i] + X[i]**2)**3
        
        new_Y = sub_matrix(Y, np.matmul(np.linalg.inv(W), F))
        delta_Y = sub_matrix(new_Y, Y)
        Y = new_Y

    fig, ax = plt.subplots()
    plt.title("Task 3: y'' = (y + x^2)^3")
    print(X[-2], Y[-2])
    ax.plot(X, Y, "-")
    plt.show()

solution()
