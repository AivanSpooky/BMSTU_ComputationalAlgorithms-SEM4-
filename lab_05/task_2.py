from math import exp, sqrt, pi, fabs
import numpy as np

fi_value = 0
N = 1000

def integral_middle_method(interval, func):
    n = len(interval)
    a = interval[0]
    b = interval[n - 1]
    h = (b - a) / n

    return h * sum([func(interval[i] + h / 2) for i in range(n - 1)])

def Laplas(x, count = 1000, method = integral_middle_method):
    def integral(x):
        return exp(-x ** 2 / 2)
    interval = np.linspace(0, x, count)
    return 2 / sqrt(2 * pi) * method(interval, integral)

def f(x):
    return exp(-x ** 2 / 2)

def trapezoid_formula(x):
    res = (f(0)  + f(x)) / 2
    
    for i in range(1, N):
        res += f(i * x / N)
    
    return res * x / N

def F_laplace(x):
    return (2 / sqrt(2 *pi)) * trapezoid_formula(x)

def F(x):
    return F_laplace(x) - fi_value

# def F(x):
#     return Laplas(x)

def half_division_method(a, b, eps):
    mid = (a + b) / 2
    while fabs((b - a)/mid) >  eps:
        mid = (a + b) / 2
        
        if F(a) * F(mid) <= 0:
            b = mid
        elif F(b) * F(mid) <=0:
            a = mid
    return round(mid, 6)


def task_2():         

    left = 0
    right = 1

    eps = 1e-6
    
    global fi_value
    fi_value = float(input("ВВедите значение функции Лапласа: "))
    
    if not -1 < fi_value < 1:
        print("Значение функции Лапласа в интервале (0, 1)")
        return
    
    print("Значение аргумента x = ", half_division_method(left, right, eps))
    
   # 1000 разбиений
   # 0 , 1 
task_2()

        