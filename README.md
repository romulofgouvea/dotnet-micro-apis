# Teste Comunicação Entre Containers

## Objetivo
Criar 2 API's com seus respectvos endpoints e fazer a comunicação entre elas

### API 1
    Endpoint: 
        /taxaJuros
        
### API 2
    Endpoint:
        /calculajuros
            Parametros da query: valorinicial e meses
        /showmethecode

O calculo da API 2 na rota `/calculajuros` depende da rota `/taxaJuros` da API 1. 

O calculo é dado pela fórmula:

```
Valor Final = Valor Inicial * (1 + juros) ^ Tempo
```

- Valor Inicial é passado como parametro pela rota(valorinicial).
- Juros é buscado na rota `/taxaJuros` da API 1.
- Tempo é passado como parâmetro pela rota(meses).


Sendo assim faz com que o serviço da API 2 fique dependente do serviço da API 1.


## Execução

Para iniciar o ambiente é preciso do .NET 5 SDK instalado. Para isso acesso o [site](https://dotnet.microsoft.com/download).

Com o dotnet instalado, entre na pasta principal do projeto, e execute o comando abaixo para iniciar a API 1:

```
dotnet run -p ./Api1/Api1.Application
```

Após o comando o terminal irá ficar em modo de espera com sua aplicação ja em execução. Abra o seu navegador e entre com a url [https://localhost:5001](https://localhost:5001).


Após isso voce vera a informação: `API1 started! Development` como a pagina inicial.

Para consultar os endpoints da api usamos o swagger acessado pelo link [https://localhost:5001/swagger](https://localhost:5001/swagger)

Com isso já é possivel testar o endpoint `/taxaJuros`, o link de exemplo é [https://localhost:5001/taxaJuros](https://localhost:5001/taxaJuros) e após aberto o lin será retornado o valor 0.01 fixo.

Repita o mesmo o processo para a API 2, alterando os nomes e os endpoints informados no topico anterior.

> Atenção:  a porta informada na url irá mudar de acordo com a API.

### Execução com docker

A execução tem como pre requisito a instalação da ferramenta [Docker](https://www.docker.com/products/docker-desktop).

Após a instalaçao, entre na pasta principal onde se encontra o arquivo `docker-compose.yml` e execute o comando abaixo para iniciar os containers.

```
docker-compose -f "docker-compose.yml" up -d --build
```

Após o comando as API's 1 e 2 estarão disponiveis nas portas `3334` e `4445` respectivamente.

Exemplo de consulta na API 2: [https://localhost:4445/calculajuros?valorinicial=100&meses=5](https://localhost:4445/calculajuros?valorinicial=100&meses=5)
