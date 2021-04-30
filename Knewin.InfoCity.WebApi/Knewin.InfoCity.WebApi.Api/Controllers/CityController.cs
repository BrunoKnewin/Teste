using System.Collections.Generic;
using Knewin.InfoCity.WebApi.Infrastructure;
using Knewin.InfoCity.WebApi.Model;
using Knewin.InfoCity.WebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Knewin.InfoCity.WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private CityService cityService;
        public CityController()
        {
            cityService = new CityService();
        }

        /// <summary>
        ///  Busca todos as cidades cadastradas
        /// </summary>
        /// <returns>Todas as cidades cadastradas</returns>
        [Route("FindAll")]
        [HttpGet]
        [AllowAnonymous]
        public List<City> FindAll()
        {
            return cityService.FindAll();
        }
        /// <summary>
        ///  Busca cidades específica
        /// </summary>
        /// <param name="name">nome da cidade que se deseja conhecer</param>
        /// <returns>todos os dados da cidades buscada</returns>
        [Route("FindByName")]
        [HttpPost]
        [Authorize]
        public City FindByName(string name)
        {
            return cityService.FindByName(name);
        }
        /// <summary>
        /// Nome das cidades que fazem fronteira com uma cidade específica
        /// </summary>
        /// <param name="name">nome da cidade que se deseja conhecer o nome das cidades que fazem fronteira</param>
        /// <returns>Nome das cidades que fazem fronteira</returns>
        [Route("FindBordersName")]
        [HttpPost]
        [Authorize]
        public List<string> FindBordersName(string name)
        {
            return cityService.FindBordersName(name);
        }
        /// <summary>
        /// Busca o total da população de um grupo de cidades em especifíco
        /// </summary>
        /// <param name="citiesName">vetor com o nome das cidades que se deseja conhecer o total da população</param>
        /// <returns>Total da população de um grupo de cidades</returns>
        [Route("FindTotalPopulationGroup")]
        [HttpPost]
        [Authorize]
        public int FindTotalPopulationGroup(string[] citiesName)
        {
            return cityService.FindTotalPopulationGroup(Helper.ToList(citiesName));
        }
        /// <summary>
        /// Cadastra uma nova cidade
        /// </summary>
        /// <param name="name">Nome da cidade que se deseja cadastrar</param>
        /// <param name="population">Valor total da população</param>
        /// <param name="citiesBorderName">Vetor com os nomes das cidades cadastradas que fazem fronteira *</param>
        /// <returns>Frase com o resultado do cadastro da cidade</returns>
        [Route("Create")]
        [HttpPost]
        [Authorize]
        public string Create(string name, int population, string[] citiesBorderName)
        {
            return cityService.Create(name, population, Helper.ToList(citiesBorderName));
        }
        /// <summary>
        /// Atualiza dados de uma cidade ja cadastrada
        /// </summary>
        /// <param name="name">Nome da cidade que se deseja atualizar</param>
        /// <param name="newName">Novo nome da cidade **</param>
        /// <param name="population">Número da populção **</param>
        /// <param name="citiesBorderName">Vetor com os nomes cidades fronteira **</param>
        /// <returns>Frase com o resultado do arualização da cidade</returns>
        [Route("Update")]
        [HttpPost]
        [Authorize]
        public string Update(string name, string newName = "", int population = 0, string[] citiesBorderName = null)
        {
            return cityService.Update(name, newName, population, Helper.ToList(citiesBorderName));
        }
    }
}
