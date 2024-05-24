import numpy as np
from math import *
from random import *
ESP = 1e-6

def F1(matrix_X):
    x = matrix_X[0]
    y = matrix_X[1]
    z = matrix_X[2]
    return x*x + y * y + z * z - 1 

def F2(matrix_X):
    x = matrix_X[0]
    y = matrix_X[1]
    z = matrix_X[2]
    return 2 * x * x + y * y - 4 * z 

def F3(matrix_X):
    x = matrix_X[0]
    y = matrix_X[1]
    z = matrix_X[2]
    return 3 * x * x - 4 * y + z * z 

def W(matrix_X):
    x = matrix_X[0]
    y = matrix_X[1]
    z = matrix_X[2]
    return [[2 * x, 2 * y, 2 * z], [4 * x, 2 * y, -4], [6 * x, -4, 2 * z]]

def F(matrix_X):
    return [F1(matrix_X), F2(matrix_X), F3(matrix_X)]


def sub_matrix(A, B):
    result = list()
    for i in range(len(A)):
        result.append(A[i] - B[i])
    return result

def cmp_with_esp(A):
    for i in range(len(A)):
        if (fabs(A[i]) > ESP):
            return True
    return False

def solution():
    X = [0.54, 0.54, 0.54]
    # X0 = [random(), random(), random()]
    delta_x = [-1, -1, -1]
    while (cmp_with_esp(delta_x)):
        X_new = sub_matrix(X, np.matmul(np.linalg.inv(W(X)), F(X)))
        delta_x = sub_matrix(X_new, X)
        X = X_new
    print("X = ", round(X[0], 3))
    print("Y = ", round(X[1], 3))
    print("Z = ", round(X[2], 3))
    return X 

solution()