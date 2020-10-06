import math


def f(x):
	return ( 0.9 - (0.4 * x) ) / x

def bissec(a,b,p):
	# X => Raiz procurada
	# k => Numero de iterações
	# [a,b] => intervalo que contem apenas uma raiz
	# p => precisão
	k = 0
	while abs(a - b) > p:
		k += 1
		x = (a + b) / 2
		if ( f(a) * f(x) ) > 0:
			a = x
		else:
			b = x
	return x, k

r = bissec(1, 3, 0.001)
print("x = ", r[0])
print("k = ", r[1])