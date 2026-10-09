##### Função #####

def gerar_matriz(n_linhas,n_colunas):
    matriz = []
    for j in range(n_colunas):
        linha = []
        for i in range (1, n_linhas + 1):
            linha.append(i + (n_linhas*j))
        matriz.append(linha)
    return matriz