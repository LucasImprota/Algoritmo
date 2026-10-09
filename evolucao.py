bolsa = {
    "pocao":3,
    "frutas":3}

pokemons = {
    "P_001":{"nome":"pichu",
                "tipo":"eletrico",
               
                "HP":35,
                "dano":3,

                "HP_Max":35,


                "XP":0,
                "nivel":1,
                "Evo":{"S1":"pikachu",
                      "S2":"raiochu"}},

    "P_002":{"nome":"charmander",
                "tipo":"fogo",

                "HP":35,
                "dano":3,

                "HP_Max":35,

                "XP":0,
                "nivel":1,
                "Evo":{"S1":"charmereon",
                       "S2":"charizard"}},

    "P_003":{"nome":"bulbasaur",
               "tipo":"planta",
               
                "HP":35,
                "dano":3,

                "HP_Max":35,

                "XP":0,
                "nivel":1,
                "Evo":{"S1":"ivysaur",
                       "S2":"venosaur"}},

    "P_004":{"nome":"squirtle",
               "tipo":"agua",
               
                "HP":35,
                "dano":3,

                "HP_Max":35,

                "XP":0,
                "nivel":1,
                "Evo":{"S1":"wartortle",
                       "S2":"Blastoise"}}}

fraqueza = {
    "fogo":"agua",
    "agua":"eletrico",
    "eletrico":"planta",
    "planta":"fogo"}

level_up = 50

##### Função ######

def XP(poke):
    poke["XP"] += 50
    if poke["XP"] >= level_up*poke["nivel"]:
        poke["XP"] -= level_up*poke["nivel"]
        poke["nivel"] += 1
        print(f"""                                             Seu pokemon subiu para o nivel {poke["nivel"]}
               """)
        poke["HP_Max"] += 3
        poke["dano"] += 2
        poke["HP"] += 3

        if poke["nivel"] == 3:
            nome = poke["nome"]
            poke["nome"] = poke["Evo"]["S1"]
            print(f"""                                         O seu {nome} evoluiu para um {poke["nome"]}
                   """)
        if poke["nivel"] == 5:
            nome = poke["nome"]
            poke["nome"] = poke["Evo"]["S2"]
            print(f"""                                         O seu {nome} evoluiu para um {poke["nome"]}
                   """)

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
            poke2["HP"] = 0
            print(poke2["nome"],"cedeu")
            vencedor = poke1
            perdedor = poke2
            break
        else:
            print("A vida do",poke2["nome"],"é:",poke2["HP"])
        
        poke1["HP"] -= dano2
        if poke1["HP"] <= 0:
            poke1["HP"] = 0
            print(poke1["nome"],"cedeu")
            vencedor = poke2
            perdedor = poke2
            break
        else:
            print("A vida do",poke1["nome"],"é:",poke1["HP"])

    ##### Recuperar #####

    perdedor["HP"] = perdedor["HP_Max"]

    return vencedor

def pocao(poke):
    if bolsa["pocao"] == 0:
        print("""                                      Voce não tem mais poçoes
              """)
    else:
        poke["HP"] = poke["HP_Max"]
        print("""                                      Voce usou uma pocao
              """)
        print("""                                      Seu pokemon se recuperou completamente
              """)
        bolsa["pocao"] -= 1

def frutas(poke):
    if bolsa["frutas"] == 0:
        print("""                                     Voce não tem mais frutas
              """)
    else:
        poke["HP"] += 10
        if poke["HP"] > poke["HP_Max"]:
            poke["HP"] = poke["HP_Max"]
        print("""                                         Voce usou uma fruta
            """)
        print(f"""                                        Seu pokemon se recuperou para HP: {poke["HP"]}
              """)
        bolsa["frutas"] -= 1


vencedor1 = batalhar(pokemons["P_001"],pokemons["P_004"])
XP(vencedor1)
frutas(vencedor1)

vencedor1 = batalhar(pokemons["P_001"],pokemons["P_004"])
XP(vencedor1)
frutas(vencedor1)

vencedor1 = batalhar(pokemons["P_001"],pokemons["P_004"])
XP(vencedor1)
frutas(vencedor1)

vencedor1 = batalhar(pokemons["P_001"],pokemons["P_004"])
XP(vencedor1)
frutas(vencedor1)
pocao(vencedor1)

vencedor1 = batalhar(pokemons["P_001"],pokemons["P_004"])
XP(vencedor1)

print("")
print(pokemons["P_001"])
print("")
print(pokemons["P_004"])