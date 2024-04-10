def func(x, y, z):
    return x + y + z

def func_to_file():
    with open("out.txt", "w") as f:
        i = j = k = 0
        step = 1e-3
        while (i < 5):
            j = 0
            while (j < 5):
                k = 0
                while (k < 5):
                    f.write(f"{i} {j} {k} {func(i, j, k)}\n")
                    k += step
                j += step
            i += step

func_to_file()
        
