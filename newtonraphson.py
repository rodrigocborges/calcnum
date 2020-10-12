import math
c = 0.3
w = 3
d = 0.6
k = 6

def f(x):
    p1 = math.exp(-c * x)
    p2 = math.cos(w * x)
    p3 = math.sin(w * x)
    r = (p1 * ((w * p2) - (2 * d * x))) - (c * p1 * (p3 - (d * (x**2))))
    return r

def fl(x):
    p1 = math.exp(-c * x)
    p2 = (w**2) - (c**2)
    p3 = math.sin(w * x)
    p4 = math.cos(w * x)
    p5 = 2 * c * w * p4
    p6 = d * (c**2) * (x**2)
    p7 = 4 * d * c * x
    r = -p1 * ((p2 * p3) + p5 + p6 - p7)
    return r

def NewtonRaphson(x0, p):
    x = x0 - (f(x0) / fl(x0))
    k = 1
    while abs(x - x0) > p:
        k += 1
        x0 = x
        x = x0 - (f(x0) / fl(x0))
    return x, k

dissmin = NewtonRaphson(0.5, 0.001)
dissmax = NewtonRaphson(2, 0.001)

print("x = " + str(dissmin[0]) + " | " + "k = " + str(dissmin[1]))

print("x = " + str(dissmax[0]) + " | " + "k = " + str(dissmax[1]))
