**Bem Vindo!**
--------------
Documentação e contratos disponíveis ao rodar o projeto abrirá no navegador a documentação com swagger.
Os dados das cidades (seeds) irá inserir automático ao rodar a aplicação. 

**Algoritmos**
--------------
Para rodar via linha de comando deve estar dentro do projeto Knewin.Algorithms
dotnet run 


**Autenticação**
--------------
Cadastre seu usuário, e autentique para obter o token, as requisições devem conter no cabeçalho
Authorization Bearer SEU_TOKEN

**Comandos EF Tool**
--------------
Para rodar os comandos deve ser instalado a ferramenta ef tool na versão 3.0.0 [documentação](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet);
Para rodar os comandos deve estar dentro do projeto Knewin.Infra

**Excluir a base**
--------------
dotnet ef database drop -c CityContext -s ..\Knewin.CityApi

**Adicionar migrações**
--------------
dotnet ef migrations add MIGRATION_NAME -c CityContext -s ..\Knewin.CityApi -o .\Data\Migrations

**Rodar as migrações manualmente**
--------------
dotnet ef database update -c CityContext -s ..\Knewin.CityApi 