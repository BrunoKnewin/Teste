#**Teste - Eduardo MPS** 
 
##Algoritmos:

**'Duplicados na lista'**

- Gerada console application "duplicados" em .Net core 3.1
- como executar compilado:
```
dotnet duplicados.dll <lista de inteiros separados por vírgula>
```
Exemplo:
```
$ dotnet duplicados.dll 002,12,4,97866,1234,9,35,3456,12,3
  Duplicado encontrado! 
  número: 12, índices: 1,8
```
---

**'Palíndromo'**
 
- Gerada console application "palindromos" em .Net core 3.1
- como executar compilado:
```
dotnet palindromos.dll "<frase ou palavra>"
```
Exemplo:
```
$ dotnet palindromos.dll "A Rita, sobre vovô, verbos atira"
CONSIDERANDO espaços e diacríticos: 
'A Rita, sobre vovô, verbos atira' não é palíndromo.
IGNORANDO espaços e diacríticos: 
'A Rita, sobre vovô, verbos atira' é palíndromo!
```
 
## API Cidades:

- Gerada WebAPI em .Net core 3.1 
- Criado, para facilitar, com base SQLite, já incluída no repositório
- Com autenticação
  - método que recebe JSON com username/password e retorna JWT
  - JWT usado como Bearer Token nos demais métodos, exceto método de listar todas

Considerando ***{URLBase}*** = https://localhost:5001/api

### Métodos

#### Login
**POST** *{URLBase}*/user/authenticate

```
curl --request POST \
  --url https://localhost:5001/api/user/authenticate \
  --header 'content-type: application/json' \
  --data '{
	"Username":"eduardo",
	"Password":"teste"
}'
```
**Retorno**:
```
{
  "id": 1,
  "username": "eduardo",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1ODQzMDg1NzgsImV4cCI6MTU4NDMxNTc3OCwiaWF0IjoxNTg0MzA4NTc4fQ.aa_PP57NRXXV5fPE-DL8UOOw1z-WY7GHElWeFnAZo9E"
}
```

***Obs.:*** dois usuários hardcoded, o do exemplo e "eduardo"/"teste"

#### Listar cidades
**GET** *{URLBase}*/city/

```
curl --request GET \
  --url https://localhost:5001/api/city/
```
**Retorno**:
```
[
  {
    "id": 1,
    "name": "Florianopolis",
    "population": 500000,
    "countryState": "SC",
    "cityRoutes": [],
    "cityRoutesFrom": [],
    "neighbors": []
  },

  ...

  {
    "id": 13,
    "name": "Canelinha",
    "population": 12000,
    "countryState": "SC",
    "cityRoutes": [],
    "cityRoutesFrom": [],
    "neighbors": []
  }
]
```
***Obs.:***
1) único método permitido sem autenticação 
2) este método não retorna as cidades vizinhas, intencionalmente

#### Buscar Cidade
**GET** *{URLBase}*/city/{id}

```
curl --request GET \
  --url https://localhost:5001/api/city/1 \
  --header 'authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1ODQzMDc5MDcsImV4cCI6MTU4NDMxNTEwNywiaWF0IjoxNTg0MzA3OTA3fQ.Hml_DakcrvnpS3XVz-pdnIcvo0BUaQSekEg6iHrtCjY'
```
**Retorno**:
Caso não encontre pelo id, retorna 404;
Caso contrário:
```
{
  "id": 1,
  "name": "Florianopolis",
  "population": 500000,
  "countryState": "SC",
  "cityRoutes": [
    {
      "idCity": 1,
      "idCityTo": 2,
      "cityTo": {
        "id": 2,
        "name": "Sao Jose",
        "population": 243000,
        "countryState": null,
        "cityRoutes": [],
        "cityRoutesFrom": [],
        "neighbors": []
      }
    }
  ],
  "cityRoutesFrom": [],
  "neighbors": [
    {
      "id": 2,
      "name": "Sao Jose",
      "population": 243000,
      "countryState": null,
      "cityRoutes": [],
      "cityRoutesFrom": [
        {
          "idCity": 1,
          "idCityTo": 2
        }
      ],
      "neighbors": []
    }
  ]
}
```

#### Criar Cidade
**POST** *{URLBase}*/city/create

```
curl --request POST \
  --url https://localhost:5001/api/city/create \
  --header 'authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1ODQzMDc5MDcsImV4cCI6MTU4NDMxNTEwNywiaWF0IjoxNTg0MzA3OTA3fQ.Hml_DakcrvnpS3XVz-pdnIcvo0BUaQSekEg6iHrtCjY' \
  --header 'content-type: application/json' \
  --data '{
    "name": "Canelinha",
    "population": 12000,
    "countryState": "SC"
  }'
```
**Retorno:**
Em caso de sucesso,status 201, Created At redirecionando para o método anterior:
```
{
  "id": 1,
  "name": "Florianopolis",
  "population": 500000,
  "countryState": "SC",
  "cityRoutes": [
    {
      "idCity": 1,
      "idCityTo": 2,
      "cityTo": {
        "id": 2,
        "name": "Sao Jose",
        "population": 243000,
        "countryState": null,
        "cityRoutes": [],
        "cityRoutesFrom": [],
        "neighbors": []
      }
    }
  ],
  "cityRoutesFrom": [],
  "neighbors": [
    {
      "id": 2,
      "name": "Sao Jose",
      "population": 243000,
      "countryState": null,
      "cityRoutes": [],
      "cityRoutesFrom": [
        {
          "idCity": 1,
          "idCityTo": 2
        }
      ],
      "neighbors": []
    }
  ]
}
```

#### Cidades limítrofes
**GET** *{URLBase}*/city/{id}/limits
```
curl --request GET \
  --url https://localhost:5001/api/city/5/limits \
  --header 'authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1ODQzMDc5MDcsImV4cCI6MTU4NDMxNTEwNywiaWF0IjoxNTg0MzA3OTA3fQ.Hml_DakcrvnpS3XVz-pdnIcvo0BUaQSekEg6iHrtCjY'
```
**Retorno:**
Caso não encontre pelo id, retorna 404;
Caso contrário:
```
{
  "city": "Palhoca",
  "neighbors": "Santo Amaro da Imperatriz,Sao Pedro de Alcantara,Sao Jose"
}
```

#### Soma de Habitantes
**GET** *{URLBase}*/city/population/{idsCSV}
```
curl --request GET \
  --url 'https://localhost:5001/api/city/population/1,2,4' \
  --header 'authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1ODQzMDc5MDcsImV4cCI6MTU4NDMxNTEwNywiaWF0IjoxNTg0MzA3OTA3fQ.Hml_DakcrvnpS3XVz-pdnIcvo0BUaQSekEg6iHrtCjY'
```

**Retorno:**

```
{
  "cities": "Florianopolis,Sao Jose,Biguacu",
  "totalPopulation": 812000
}
```

#### Atualizar Cidade
**POST** *{URLBase}*/city/{id}/update

```
curl --request POST \
  --url https://localhost:5001/api/city/13/update \
  --header 'authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1ODQzMDc5MDcsImV4cCI6MTU4NDMxNTEwNywiaWF0IjoxNTg0MzA3OTA3fQ.Hml_DakcrvnpS3XVz-pdnIcvo0BUaQSekEg6iHrtCjY' \
  --header 'content-type: application/json' \
  --data '{
    "name": "Canelinha",
    "population": 12000,
    "countryState": "SC"
}'
```
**Retorno:**
Caso não encontre pelo id, status 404
Caso contrário, status 204 (NoContent)

#### Caminho Entre Cidades
**GET** *{URLBase}*/city/findpath/{idCityFrom}/{idCityTo}
```
curl --request GET \
  --url https://localhost:5001/api/city/findpath/10/6 \
  --header 'authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE1ODQzMDc5MDcsImV4cCI6MTU4NDMxNTEwNywiaWF0IjoxNTg0MzA3OTA3fQ.Hml_DakcrvnpS3XVz-pdnIcvo0BUaQSekEg6iHrtCjY'
```
**Retorno:**
Caso não encontre início ou destino pelo id, status 404
Caso contrário
```
{
  "start": "Sao Joao Batista",
  "end": "Santo Amaro da Imperatriz",
  "path": "Sao Joao Batista,Antonio Carlos,Sao Pedro de Alcantara,Santo Amaro da Imperatriz"
}
```