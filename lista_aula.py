lista = []

tam = int(input("Qual o tamanho da lista: "))
x=0
while x < tam:
    item = input("Escolha um item: ")
    quant = input("Digite a quantidade desse item: ")
    lista.append([item, quant])
    x += 1

while True:
    print("Aqui está sua lista:",lista)
    resp = str.lower(input("deseja remover algum item da lista: "))
    if resp == "sim":
        rem =int(input("Qual posição esta o item que deseja remover: "))
        print("Removendo o item: ",lista[rem - 1])
        lista.pop(rem - 1)
    else:
        break

print("Operações finalizadas")


