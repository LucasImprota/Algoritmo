salario = int(input("Qual valor voce que checar: "))
tempo = int(input("Qual o tempo de casa: "))

if salario >= 2000:
    aumento = salario*1.05
else:
    if tempo < 10:
        aumento = salario*1.1
    else:
        aumento = salario*1.15

diferenca = aumento-salario

print(f"""O seu novo salario será: {aumento}
            Com um aumento de: {diferenca}""")