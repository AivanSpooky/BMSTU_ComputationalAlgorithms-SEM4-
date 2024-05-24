from math import exp, sqrt, pi
import numpy as np

fi_value = 0
N = 1000

def integral_middle_method(interval, func):
    n = len(interval)
    a = interval[0]
    b = interval[n - 1]
    h = (b - a) / n

    return h * sum([func(interval[i] + h / 2) for i in range(n - 1)])

def Laplas(x, count=1000, method=integral_middle_method):
    def integral(x):
        return exp(-x ** 2 / 2)
    interval = np.linspace(0, x, count)
    return 2 / sqrt(2 * pi) * method(interval, integral)

def f(x):
    return exp(-x ** 2 / 2)

def trapezoid_formula(x):
    res = (f(0) + f(x)) / 2
    
    for i in range(1, N):
        res += f(i * x / N)
    
    return res * x / N

def F_laplace(x):
    return (2 / sqrt(2 * pi)) * trapezoid_formula(x)

def F(x):
    return F_laplace(x) - fi_value

def fixed_point_iteration(g, x0, iterations):
    x = x0
    for _ in range(iterations):
        x = g(x)
    return round(x, 6)

def task_2():
    left = 0
    right = 1
    iterations = 1000

    global fi_value
    fi_value = float(input("Введите значение функции Лапласа: "))
    
    if not -1 < fi_value < 1:
        print("Значение функции Лапласа должно быть в интервале (-1, 1)")
        return
    
    
    def g(x):
        return x - F(x) 
    
    initial_guess = (left + right) / 2
    result = fixed_point_iteration(g, initial_guess, iterations)
    
    print("Значение аргумента x = ", result)

task_2()
