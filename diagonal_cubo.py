lado = int(input("Qual o lado do cubo: "))

Diagonal_lat = (lado**2 + lado**2)**(1/2)

Diagonal = (lado**2 + Diagonal_lat**2)**(1/2)

print("A diagonal do cubo é:",Diagonal)