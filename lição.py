lista = []
respostas = ["sim","nao","não"]

while True:
    item = input("Adicione um item na lista: ")
    quant = int(input("Qual a quantidade desse item: "))
    lista.append([item,quant])
    x = 0
    resp = str.lower(input("Deseja adionar outa item na lista: "))
    while resp not in respostas:
        print("ERRO: Tente novamente")
        resp = str.lower(input("Deseja adionar outa item na lista: "))
    if resp == "nao" or resp == "não":
        break
    


print("Aqui está sua lista:", lista)