import numpy as np
import matplotlib.pyplot as plt
from spline import *
cn = 0.01
def read_from_file(filename):
    data_x = []
    data_y = []
    data = [data_x, data_y, []]
    with open(filename, 'r') as f:
        i = 0
        for line in f:
            if i == 0:
                elem_x = line.split()
                elem_x = elem_x[1:]
                data[0] = [float(e) for e in elem_x]
                i += 1
            else:
                elem = line.split()
                if len(elem):
                    data[1].append(float(elem[0]))
                    elem = elem[1:]
                    data[2].append([float(e) for e in elem])
    return data

data = read_from_file("./text.txt")

def legendre_polynomial(n, x):
    if isinstance(x, (float, np.float64)):
        x = np.array([x])
    length = len(x)
    if n == 0:
        return np.ones(length)
    elif n == 1:
        return x
    else:
        P_n_minus_1 = x
        P_n_minus_2 = np.ones(length)
        for k in range(2, n + 1):
            P_n = ((2 * k - 1) * x * P_n_minus_1 - (k - 1) * P_n_minus_2) / k
            P_n_minus_2 = P_n_minus_1
            P_n_minus_1 = P_n
        return P_n

def sympson(x : list, f):
    def symfunc(a, b):
        return ((b - a) / 6) * (f(a) + 4 * f ((a + b) / 2) + f(b))

    return sum([symfunc(x[i], x[i + 1])  for i in range(len(x) - 1)]) - cn
# def sympson(x, f):
#     def func(a, b):
#         return ((b - a) / 6) * (f(a) + 4 * f((a + b) / 2) + f(b))
#     return sum([func(x[i], x[i + 1]) for i in range(len(x) - 1)])


def integrate_simpson(x, f):
    n = len(x) - 1
    h = (x[-1] - x[0]) / n
    y = [f(xi) for xi in x]
    return h / 3 * (y[0] + 2 * sum(y[i] for i in range(2, n, 2)) + 4 * sum(y[i] for i in range(1, n, 2)) + y[n])


def create_triangle_matrix(data, n):
    for k in range(n):
        for i in range(k + 1, n):
            if data[k][k] != 0:
                coeff = -(data[i][k] / data[k][k])
            else:
                coeff = 0 
            for j in range(k, n + 1):
                data[i][j] += coeff * data[k][j]
    return data

def Gauss(data):
    n = len(data)
    triangle_data = create_triangle_matrix(data, n)

    result = np.zeros(n)
    for i in range(n - 1, -1, -1):
        for j in range(n - 1, i, -1):
            data[i][n] -= result[j] * data[i][j]
        if data[i][i] != 0:
            result[i] = data[i][n] / data[i][i]
        else: result[i] = 0
    return result

def legendre_polynomial_derivative(n, x):
    if isinstance(x, (float, np.float64)):
        x = np.array([x])
    P_n = legendre_polynomial(n, x)
    P_n_minus_1 = legendre_polynomial(n - 1, x)
    return n / (-1 + x ** 2) * (x * P_n - P_n_minus_1)

def find_root_newton(func, x0, n, tol=1e-6, max_iter=100):
    x = x0
    for _ in range(max_iter):
        fx = func(x)
        if isinstance(fx, np.ndarray):
            fx = fx[0]
        if np.abs(fx) < tol:
            return x
        dfx = legendre_polynomial_derivative(n, x)
        if isinstance(dfx, np.ndarray):
            dfx = dfx[0]
        x -= fx / dfx
    return x

def find_roots_legendre(n):
    roots = np.zeros(n)
    for i in range(1, n + 1):
        x0 = np.cos(np.pi * (i - 0.25) / (n + 0.5))
        root = find_root_newton(lambda x: legendre_polynomial(n, x), x0, n)
        roots[i - 1] = root
    return roots

def find_integral(a, b, n, f):
    tmp = find_roots_legendre(n)
    x_val = [(a + b) / 2 + (b - a) / 2 * t for t in tmp]
    Amatrix = [[tmp[j] ** i for j in range(n)] for i in range(n)]
    
    Y = [2 / (i + 1) if i % 2 == 0 else 0 for i in range(n)]
    for i in range(n):
        Amatrix[i].append(Y[i])
    Acoeffs = Gauss(Amatrix)
    return (b - a) / 2 * sum([Acoeffs[i] * f(x_val[i]) for i in range(n)])

def func(x, y):
    return x**2 + y**2 + 1

def Spline(data):
    def f(x0, y0):
        return find_spline(data, x0, y0, 0, 0)  # Устанавливаем start и end в 0, так как они не используются в функции spline
    return f

def integrand(x, y):
    if x**2 + y**2 >= 1 and x**2 + y**2 <= 4:
        return x**2 * y**2
    else:
        return 0

N_Y = 4
N_X = 9

##
def integ(x):
    return find_integral(-np.sqrt(4 - x ** 2), np.sqrt(4 - x ** 2), N_Y, lambda y: x ** 2 * y ** 2)

res = integrate_simpson(np.linspace(-2, 2, N_X), integ)
print(f"Двукратный интеграл: {res}")
##



