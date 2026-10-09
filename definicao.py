import numpy as np
import matplotlib.pyplot as plt

def solicitar_pontos():
    pontos = []
    for i in range(4):
        x, y = map(float, input(f"Digite as coordenadas do ponto {i+1} (x y): ").split())
        pontos.append([x, y])
    return np.array(pontos)

def solicitar_matriz():
    print("Digite os elementos da matriz 2x2 linha por linha:")
    matriz = []
    for i in range(2):
        linha = list(map(float, input().split()))
        matriz.append(linha)
    return np.array(matriz)

def transformar_pontos(matriz, pontos):
    return np.array([matriz @ p for p in pontos])

def plotar_pontos(pontos_iniciais, pontos_transformados):
    plt.figure(figsize=(6, 6))
    
    # Fechando a figura
    pontos_iniciais = np.vstack([pontos_iniciais, pontos_iniciais[0]])
    pontos_transformados = np.vstack([pontos_transformados, pontos_transformados[0]])
    
    # Plotando os pontos iniciais conectados
    xi, yi = zip(*pontos_iniciais)
    plt.plot(xi, yi, 'bo-', label='Figura Inicial', linewidth=2)
    
    # Plotando os pontos transformados conectados
    xt, yt = zip(*pontos_transformados)
    plt.plot(xt, yt, 'ro-', label='Figura Transformada', linewidth=2)
    
    # Ligando os pontos iniciais aos transformados
    for i in range(len(pontos_iniciais) - 1):
        plt.plot([xi[i], xt[i]], [yi[i], yt[i]], 'gray', linestyle='dashed', alpha=0.6)
    
    plt.axhline(0, color='black', linewidth=0.5)
    plt.axvline(0, color='black', linewidth=0.5)
    plt.grid(True, linestyle='--', linewidth=0.5)
    plt.legend()
    plt.title("Transformação Linear de Pontos")
    plt.show()

def main():
    pontos = solicitar_pontos()
    matriz = solicitar_matriz()
    pontos_transformados = transformar_pontos(matriz, pontos)
    print("Pontos transformados:", pontos_transformados)
    plotar_pontos(pontos, pontos_transformados)

if __name__ == "__main__":
    main()
