
numeros = []
print("Digite -1 para interromper")

x= 0

while True:
    x = int(input("Adicione um numero: "))
    if x != -1:
        numeros.append(x)
    else:
        break

tamanho = len(numeros)
i = 0
j = 0

for i in range(tamanho):
    for j in range(i):
        if numeros[j] > numeros[i]:
            x = numeros[i]
            numeros[i]=numeros[j]
            numeros[j]=x
        j += 1
    i += 1


print(numeros)