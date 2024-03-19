class Point:
    def __init__(self, x, y, dx, ddx):
        self.x = x
        self.y = y
        self.dx = dx
        self.ddx = ddx
        self.isExit = True

    def getX(self):
        return self.x

    def getY(self):
        return self.y

    def getDerivative(self):
        return self.dx
    
    def getSecDerivative(self):
        return self.ddx

    def setX(self, x):
        self.x = x

    def setY(self, y):
        self.x = y

    def setDerivative(self, dx):
        self.dx = dx

    def setSecDerivative(self, ddx):
        self.ddx = ddx