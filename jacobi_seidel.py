import numpy as np

def jacobi(A, B, p):
    # x => vetor solucao
    # k => n de iteracoes
    # a,b => matriz e vetor do sistema
    # p => precisao
    n = np.max(np.shape(A))
    k = 0
    x0 = np.zeros(n)
    alf = np.zeros(n)
    for i in range(n):
        x0[i] = 1
        s = 0
        for j in range(n):
            if j != i:
                s = s + abs(A[i][j])
        alf[i] = s / abs(A[i][i])

    x = np.zeros(n)
    if np.max(alf) < 1:
        test = 1000
        while test > p:
            k += 1
            for i in range(n):
                s = 0
                for j in range(n):
                    if j != i:
                        s = s + (A[i][j] * x0[j])
                x[i] = (B[i] - s) / A[i][i]
            test = np.max(np.absolute(x - x0))
            x0 = x.copy()
        x = np.transpose(x)
    else:
        x = 'Não converge'

    return x, k


def sidel(A, B, p):
    # x => Vetor Solucao
    # k => n iteracoes
    # a,b => matriz e vetor do sistema
    # p => precisao
    n = np.max(np.shape(A))
    k = 0

    x0 = np.zeros(n)
    bet = np.zeros(n)
    for i in range(n):
        x0[i] = 0.5
        s = 0
        for j in range(n):
            if j != i:
                if j > i:
                    s = s + abs(A[i][j])
                else:
                    s = s + (bet[j] * abs(A[i][j]))
        bet[i] = s / abs(A[i][i])

    x = np.full(n, 0.5)
    if np.max(bet) < 1:
        teste = 1000
        while teste > p:
            k += 1
            for i in range(n):
                s = 0
                for j in range(n):
                    if j != i:
                        s = s + (A[i][j] * x[j])
                x[i] = (B[i] - s) / A[i][i]
            teste = np.max(np.absolute(x - x0))
            x0 = x.copy()
        x = np.transpose(x)
    else:
        x = 'Não Converge'

    return x, k


A = np.array([[-4, -1, 2], 
			[1, 6, -1], 
			[4, -3, -13]])
B = np.array([[7], [-6], [6]])
p = 0.001

print("Jacobi")
print(jacobi(A, B, p))
print("Sidel")
print(sidel(A, B, p))
