using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cidades.Infrastructure.Services;
using cidades.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace cidades.Controllers
{
    
    [ApiController, Route("api/[controller]"), AllowAnonymous]//, Authorize]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly CityService _service;

        public CityController(ILogger<CityController> logger, CityService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]//, AllowAnonymous]
        public IActionResult List()
        {
            var cities = _service.List();
            return Ok(cities);
        }

        [HttpPost, Route("create")]
        public IActionResult Create([FromBody]City city)
        {
            City cityDb = _service.Find(city.Name, city.CountryState);
            if(cityDb!=null)
                return BadRequest(new { Error = "Cidade já existe na base!" });
            _service.Create(city);
            return CreatedAtAction(nameof(Get), new { id = city.Id }, city);
        }

        [HttpGet,Route("{id:int}")]
        public IActionResult Get(int id)
        {
            City city = _service.Get(id);
            if(city==null)
                return NotFound();
            return Ok(city);
        }

        [HttpPost("{id:int}/update")]
        public IActionResult Update(int id, [FromBody]City city)
        {
            City cityDb = _service.Get(id);
            if(cityDb==null)
                return NotFound();

            _service.Update(id, city);
            return NoContent();
        }

        [HttpGet("population/{idList:regex(^(\\d+)(,\\d+)*$)}")]
        public IActionResult SumPopulation(string idList)
        {
            List<City> cities = _service.GetCities(idList);
            long totalPop = cities.Sum(c => c.Population);
            string names = string.Join(',',cities.Select(c => c.Name).ToList());
            return Ok(new { Cities = names, TotalPopulation = totalPop });
        }

        [HttpGet("{id:int}/limits")]
        public IActionResult Limits(int id)
        {
            //todo get city
            City city = new City(){Id = id};
            string neighborNames = string.Join(',',city.Neighbors.Select(c => c.Name).ToList());
            return Ok(new { City = city.Name, Neighbors = neighborNames });
        }

        [HttpGet("findpath/{idFrom:int}/{idTo:int}")]
        public IActionResult FindPath(int idFrom, int idTo)
        {
            //todo get path
            List<City> path = new List<City>();
            string pathCityNames = string.Join(',',path.Select(c => c.Name).ToList());
            return Ok(new { Path = pathCityNames });
        }
    }
}