**Olá Avaliador!**
# 
Abaixo as orientações de execução do projeto.
 
 
` Algoritmos `

- O projeto EZ.Knewin.Teste.Algoritmos está dentro da solução com os algoritmos resolvidos.
- Rode pelo VS de sua preferência ou via comando "dotnet run" na pasta do projeto.


` Projeto: Banco de dados `
 
- Executar o comando "Update-Database" no Package Manager Console ou via CLI se preferir.
- Obs.: Caso o banco não seja criado, verifique as permissões de escrita do seu ambiente.
 
 
 ` Projeto `

 - Executar o projeto EZ.Knewin.Teste.Api com "dotnet run"
 - Porta default: http://localhost:5000


` Projeto: Login`
  
- /api/login
- Usuario padrão "admin" e senha "admin"
- Será gerado um Token que deverá ser utilizado nas demais requisições.


` Projeto: Estados `

- Criado para categorizar cidades, opcional no teste mas obrigatorio no cadastro de cidades.
- GET: /api/estado          -> Retorna todos os Estados com Id, Nome e Sigla


` Projeto: Cidades `
 
- POST: /api/cidade                             -> Cadastro de Cidades
- GET: /api/cidade                              -> Lista completa de Cidades (sem autenticação)
- GET: /api/cidade/{id}                         -> Obter Cidade por Id
- GET: /api/cidade/{id}/fronteiras              -> Obter Cidades que fazem fronteira com a cidade indicada
- PUT: /api/cidade/{id}                         -> Atualiza cidade
- GET: /api/cidade/total-de-habitantes/{int[]}  -> Retorna o total de habitantes das cidades indicadas por id
