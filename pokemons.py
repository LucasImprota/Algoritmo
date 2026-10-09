pokemons = {
    "Pikachu":{"nome":"pikachu",
               "tipo":"eletrico",
               "HP":35,
               "dano":3},
    "Charmander":{"nome":"charmander",
               "tipo":"fogo",
               "HP":35,
               "dano":3},
    "Bulbasaur":{"nome":"bulbasaur",
               "tipo":"planta",
               "HP":35,
               "dano":3},
    "Squirtle":{"nome":"squirtle",
               "tipo":"agua",
               "HP":35,
               "dano":3}}

fraqueza = {
    "fogo":"agua",
    "agua":"eletrico",
    "eletrico":"planta",
    "planta":"fogo"}

HP1 = pokemons["Pikachu"]["HP"]
HP2 = pokemons["Charmander"]["HP"]
HP3 = pokemons["Bulbasaur"]["HP"]
HP4 = pokemons["Squirtle"]["HP"]

##### Função ######

def batalhar(poke1,poke2):

    ##### Fraquezas #####
    
    if poke1["tipo"] == fraqueza[poke2["tipo"]]:
        dano1 = poke1["dano"]*2
        dano2 = poke2["dano"]
    elif poke2["tipo"] == fraqueza[poke2["tipo"]]:
        dano1 = poke1["dano"]
        dano2 = poke2["dano"]*2
    else:
        dano1 = poke1["dano"]
        dano2 = poke2["dano"]

    ###### Batalha #####

    while True:

        poke2["HP"] -= dano1
        if poke2["HP"] <= 0:
            print(poke2["nome"],"cedeu")
            vencedor = poke1
            break
        else:
            print("A vida do",poke2["nome"],"é:",poke2["HP"])
        
        poke1["HP"] -= dano2
        if poke1["HP"] <= 0:
            print(poke1["nome"],"cedeu")
            vencedor = poke2
            break
        else:
            print("A vida do",poke1["nome"],"é:",poke1["HP"])

    ##### Recuperar #####

    pokemons["Pikachu"]["HP"] = HP1
    pokemons["Charmander"]["HP"] = HP2
    pokemons["Bulbasaur"]["HP"] = HP3
    pokemons["Squirtle"]["HP"] = HP4

    return vencedor

vencedor1 = batalhar(pokemons["Pikachu"],pokemons["Squirtle"])
print("O vencedor da primeira batalha é:",vencedor1["nome"])

vencedor2 = batalhar(pokemons["Charmander"],pokemons["Bulbasaur"])
print("O vencedor da segunda batalha é:",vencedor2["nome"])

campeao = batalhar(vencedor1,vencedor2)
print("O campeão é:",campeao["nome"])