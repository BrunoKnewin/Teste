////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Projeto Knewin.InfoCity.WebApi


--Ferramentas utilizadas
	- Visual Studio 2019
	- Asp.Net Core 3.1
	- Entity Framework Core 5.05
	- Asp.Net Core Atuthentication 2.2.0
	- Sql Server 2019
	- Sql Server Management Studio 18

--Iniciando o projeto
	- Baixar, clonar ou fazer um pull do projeto "Teste"
	- Criar banco de dados, sua estrutura e informações a partir do script InfoCityScriptDB.sql contido dentro da pasta principal (!)
		
		--Rodando o projeto
			- Abra o arquivo "appsettings.json" contido no caminho "...\Teste\Knewin.InfoCity.WebApi\Knewin.InfoCity.WebApi.Api" e ajuste o nome do servidor Sql Server 
			  na seção "ConnectionStrings". Exemplo: "Data Source=NomeDoSeuServidor;Initial Catalog=InfoCityDB;Integrated Security=True"
			
			- Abrir o terminal e navegar ate a pasta do projeto "...\Teste\Knewin.InfoCity.WebApi\Knewin.InfoCity.WebApi.Api" e rodar o comando "dotnet watch run"
			
			- Guardar a porta contida no host "Now listening on:"
			
			- Abrir "Postman" e ajustar tipo de requisição que se deseja fazer e valor do dominio combinado com a pora (ex: "localhost:5000/") 
			
			- Desabilitar a opção "Enable SSL certificate verification" na aba "Settings"
					
					--Realizando requisições que não necessitam de Autenticação
						-Ajustar os parametros individuais ou o objeto Json de acordo com a requisição
						
						- Realizar as requisições da API de acordo com a documentação abaixo
					
					--Realizando requisições que necessitam de Autenticação
						- Fazer um POST de autenticação com o metodo "/User/Login" como descrito da documentação da API abaixo
						
						- Guardar o valor do token recebido como resposta do passo acima
						
						- Na aba "Authorization" selecionar no seletor "Type" o tipo de autorização "Bearer Token" e colocar o valor do token no campo           					   "Token"
						
						- Realizar as requisições da API de acordo com a documentação abaixo
	
	(!) Outra opção para iniciar o banco de é abrir abrir a aplicação com o visual studio a partir do diretório navegando ate a pasta "...\Teste\Knewin.InfoCity.WebApi".
	    Com o projeto aberto, abrir o "Console de gerenciador de pacotes", ajustar o projeto padãro para Knewin.InfoCity.Dal e definir o projeto "Knewin.InfoCity.WebApi.Api" 
	    como "projeto de inicialização" no "Gerenciador de soluções". Rodar o comando "Update-database" e subir o arquivo com os dados "InfoCityScriptOnlyData.sql" para o 		    Sql Server.

-Documentação 

	POST localhost:5000/api/User/Login
	/// <summary>
        /// Faz a autenticação de usuário para acesso as requisições da api
        /// </summary>
        /// <param name="user">Nome e senha de usuário</param>
        /// <returns>Mensagem informando erro de autenticação</returns>
        /// <returns>Dados de usuário e token de authenticação</returns>
		
		Content-type: application/json
		user= {"Name":"nomeDeUsuário","Password","senhaDeUsuário"}


	GET localhost:5000/api/City/FindAll
	/// <summary>
	///  Busca todos as cidades cadastradas
	/// </summary>
	/// <returns>Todas as cidades cadastradas</returns>
	
	
	POST localhost:5000/api/City/FindByName
	/// <summary>
        ///  Busca cidades específica
        /// </summary>
        /// <param name="name">nome da cidade que se deseja conhecer</param>
        /// <returns>todos os dados da cidades buscada</returns>


	POST localhost:5000/api/City/FindBordersName
	/// <summary>
        /// Nome das cidades que fazem fronteira com uma cidade específica
        /// </summary>
        /// <param name="name">nome da cidade que se deseja conhecer o nome das cidades que fazem fronteira</param>
        /// <returns>Nome das cidades que fazem fronteira</returns>

	POST localhost:5000/api/City/FindTotalPopulationGroup
	/// <summary>
        /// Busca o total da população de um grupo de cidades em especifíco
        /// </summary>
        /// <param name="citiesName">vetor com o nome das cidades que se deseja conhecer o total da população</param>
        /// <returns>Total da população de um grupo de cidades</returns>
		
		Content-type: application/json
		citiesName = ["cidadeA","cidadeB","cidadeC"]

	POST localhost:5000/api/City/Create
	/// <summary>
        /// Cadastra uma nova cidade
        /// </summary>
        /// <param name="name">Nome da cidade que se deseja cadastrar</param>
        /// <param name="population">Valor total da população</param>
        /// <param name="citiesBorderName">Vetor com os nomes das cidades cadastradas que fazem fronteira *</param>
        /// <returns>Frase com o resultado do cadastro da cidade</returns>
		
		Content-type: application/json
		citiesBorderName = ["cidadeA","cidadeB","cidadeC"]
		
		Para novas cidades sem fornteiras declaradas, citiesBorderName:[]
		

	POST localhost:5000/api/City/Update
	/// <summary>
        /// Atualiza dados de uma cidade ja cadastrada
        /// </summary>
        /// <param name="name">Nome da cidade que se deseja atualizar</param>
        /// <param name="newName">Novo nome da cidade **</param>
        /// <param name="population">Número da populção **</param>
        /// <param name="citiesBorderName">Vetor com os nomes cidades fronteira **</param>
        /// <returns>Frase com o resultado do arualização da cidade</returns>
		
		Content-type: application/json
		citiesBorderName = ["cidadeA","cidadeB","cidadeC"]
		
		* Parametro opcional
		** Parametro opcional somente se desejar atualizar
		
		
-Permissões
		
		Tipo			Caminho											Permissão

		POST			/api/User/Login										Não autenticado
		GET			/api/City/FindAll									Não autenticado
		POST			/api/User/FindByName									Autenticado
		POST			/api/User/FindBordersName								Autenticado
		POST			/api/User/FindTotalPopulationGroup							Autenticado
		POST			/api/User/Create									Autenticado
		POST			/api/User/Update									Autenticado
		
		
-Usuário cadastrada para login
		
		Name = Knewin
		
		Password = 123456
		
		
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Algoritimos
   --Ferramentas utilizadas
	- Visual Studio 2019
	- Asp.Net Core 3.1
	

//Projeto Knewin.FirstNumberRepeat.ConsoleApp

--Iniciando o projeto
	
	- Baixar, clonar ou fazer um pull do projeto "Teste"
		
		--Rodando o projeto
			
			- Abrir o terminal e navegar ate a pasta do projeto "...\Teste\Algoritimos\Knewin.FirstNumberRepeat.ConsoleApp" e compilar a classe  		   				"FirstNumberRepeat.cs"
			
			- Execultar arquivo criado
				
				- (Opicinal) Navegar ate a pasta do projeto 			  		"...\Teste\Algoritimos\Knewin.FirstNumberRepeat.ConsoleApp\Knewin.FirstNumberRepeat.ConsoleApp\bin\Release\netcoreapp3.1"
				- (Opicinal) Execultar o arquivo "Knewin.FirstNumberRepeat.ConsoleApp.exe"

				
				

//Projeto Knewin.Palindrome.ConsoleApp

--Iniciando o projeto
	
	- Baixar ou clonar projeto Knewin.Palindrome.ConsoleApp
		
		--Rodando o projeto
			- Abrir o terminal e navegar ate a pasta do projeto "...\Teste\Algoritimos\Knewin.Palindrome.ConsoleApp" e compilar a classe  "Palindrome.cs"
			- Execultar arquivo criado
				
				- (Opicinal) Navegar ate a pasta do projeto   	"...\Teste\Algoritimos\Knewin.Palindrome.ConsoleApp\Knewin.Palindrome.ConsoleApp\bin\Release\netcoreapp3.1"
				- (Opicinal) Execultar o arquivo "Knewin.Palindrome.ConsoleApp.exe"
				


