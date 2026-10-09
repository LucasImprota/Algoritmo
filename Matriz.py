##### Funçoes #####

def Montar_Matriz(Matriz):
    Linha = int(input("Quantas linhas tem sua matriz: "))
    Coluna = int(input("Quantas colunas tem sua matriz: "))

    Matriz = []
    print("Escolha um valor para o numero na:")
    for j in range(Coluna):
        linha = []
        for i in range (Linha):
            print("Linha", j+1, "Coluna",i+1)
            x = int(input())
            linha.append(x)
        Matriz.append(linha)

    print(Matriz)
    return Matriz

def somar(M_A, M_B):
    matriz = []
    for j in range(len(M_A)):
        linha = []
        for i in range (len(M_A[j])):
            linha.append(M_A[j][i] + M_B[j][i])
        matriz.append(linha)
    return matriz

##### Codigo Principal #####

A =[]
B = []

x = Montar_Matriz(A)
y = Montar_Matriz(B)

print("")

C = somar(x,y)
print("A soma das matrizes é:",C)