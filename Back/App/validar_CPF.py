import requests

def validar_cpf_online(cpf):
    response = requests.post("https://www.4devs.com.br/ferramentas_online.php", data={
        "acao": "validar_cpf",
        "txt_cpf": cpf
    })

    return response.content

# Exemplo de uso
print(validar_cpf_online("618.095.633-11"))
