from numpy import arange
import matplotlib.pyplot as plt


class Point:
    def __init__(self, x=0, y=0, weight=1):
        self.x = x
        self.y = y
        self.weight = weight

    def __str__(self):
        return f"|{self.x:^10.2f} | {self.y:^10.2f} | {self.weight:^10.2f} |"


def print_table(table):
    print(" _____________________________________")
    print("|      X    |      Y     |   weight   |")
    print("|-------------------------------------|")
    for i in range(len(table)):
        print(table[i])
    print("|_____________________________________|")


def read_from_file(file_input):
    dots = list()
    with open(file_input, "r") as f:
        line = f.readline()
        line = f.readline()
        while line:
            x, y, weight = map(float, line.split())
            dots.append(Point(x, y, weight))
            line = f.readline()
    return dots


def append_right_side(matrix, dots):
    for i in range(len(matrix)):
        res = 0
        for j in range(len(dots)):
            res += dots[j].weight * dots[j].y * (dots[j].x ** i)
        matrix[i].append(res)

# !!!
def get_coefficient(dots, degree):
    coefficient = 0
    for i in range(len(dots)):
        coefficient += dots[i].weight * (dots[i].x ** degree)
    return coefficient


def find_slae_matrix_3d(dots, degree):
    matrix = []
    for h in range(len(dots)):
        coefficient = 0
        row = []
        for i in range(degree + 1):
            for j in range(degree + 1):
                coefficient += dots[i].weight * (dots[i].y ** (i - j)) * (dots[i].x ** degree)
            row.append(coefficient)
        matrix.append(row)
    return matrix


def find_slae_matrix(dots, degree):
    # if (len(dots) <= degree):
    #     return None
    matrix = [[get_coefficient(dots, j + i)  # получится degree * 2
              for i in range(degree + 1)]
              for j in range(degree + 1)]
    append_right_side(matrix, dots)
    return matrix


def get_polynomial_coefficients(matrix):
    if matrix == None:
        return None
    for i in range(len(matrix)):
        for j in range(len(matrix)):
            if i == j:
                continue
            multiplication = matrix[j][i] / matrix[i][i]
            for k in range(0, len(matrix) + 1):
                matrix[j][k] -= multiplication * matrix[i][k]

    for i in range(len(matrix)):
        multiplication = matrix[i][i] 
        for j in range(len(matrix[i])):
            matrix[i][j] /= multiplication

    return [matrix[i][-1] for i in range(len(matrix))]


def add_plot(coeffs, label, start, end):
    my_x = list()
    my_y = list()
    step = (end - start) / 1000
    for x in arange(start, end + step, step):
        my_x.append(x)
        y = 0
        for i in range(len(coeffs)):
            y += coeffs[i] * x ** i
        my_y.append(y)

    plt.plot(my_x, my_y, label=label, color='green')

def phi(x, coeffs):
    y = 0
    for i in range(len(coeffs)):
        y += coeffs[i] * x ** i
    return y

def add_table(table, label):
    table_x = [table[i].x for i in range(len(table))]
    table_y = [table[i].y for i in range(len(table))]

    plt.plot(table_x, table_y, 'o', label=label)


def draw_result():
    plt.legend()

    plt.xlabel('X') 
    plt.ylabel('Y')

    plt.grid()
    plt.show()

# err = 0
# for i in range(len(x)):
#     err += p[i] * (y[i] - phi(x[i]))**2

if __name__ == "__main__":
    # filenames = input("Enter filenames: ").split()
    # label = input("Enter labels: ").split(',')
    plt.figure(figsize=(15, 15))
    filename = "tmp41.txt"
    degrees = list(map(int, input("Степень аппроксимирующего полинома: ").split()))

    points = read_from_file(filename)
    add_table(points, "Table")

    print_table(points)

    for j in range(len(degrees)):
        slae_matrix = find_slae_matrix(points, degrees[j])
        coeffs = get_polynomial_coefficients(slae_matrix)
        print(coeffs)
        if (coeffs == None):
            print("Error!!!")
        else:
            add_plot(coeffs, f"n = {degrees[j]}",
                    points[0].x, points[-1].x)
        
        err = 0
        for i in range(len(points)):
            err_i = points[i].weight * (points[i].y - phi(points[i].x, coeffs))**2
            print(err_i)
            err += err_i
        print(f"full err: {err}")
    # coeffs = [6.95, -4.114]
    # add_plot(coeffs, f"n = {degrees[j]}",
    #                 points[0].x, points[-1].x)
    
    draw_result()