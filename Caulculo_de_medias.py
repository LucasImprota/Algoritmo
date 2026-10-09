print("Calculador de média de provas.")

x = int(input("Quantas provas foram feitas: "))
total = 0
i=1
notas = []

##### Pegar as notas da prova #####

while i <= x:
    p = float(input("Qual foi a nota da prova: "))
    if p > 10 or p < 0:
        print("Erro: Nota deve estar entre 0 e 10")
    else:    
        notas.append(p)
        total += p
        i += 1

### Caulculo de media ###
resultado = total/x

### Exibir resultado ###

print("Suas notas foram:",notas)

print("Sua média é:",resultado)

if resultado >= 5:
    print("Voce foi aprovado")
else:
    print("Voce foi reprovado")