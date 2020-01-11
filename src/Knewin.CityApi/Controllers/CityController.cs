using AutoMapper;
using Knewin.CityApi.ViewModels.City;
using Knewin.CityApi.ViewModels.Frontier;
using Knewin.Domain.Entities;
using Knewin.Infra.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knewin.CityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]"), ApiVersion("1")]
    public class CityController : Controller
    {
        private readonly IMapper _mapper;

        private readonly ICityCrudService _cityCrudService;

        public CityController(IMapper mapper, ICityCrudService cityCrudService)
        {
            _mapper = mapper;
            _cityCrudService = cityCrudService;
        }

        // GET api/city
        [HttpGet]
        public ActionResult<IEnumerable<CityViewModel>> All()
        {
            return _mapper.Map<List<CityViewModel>>(_cityCrudService.GetPage(10, 0));
        }

        // GET api/city/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityViewModel>> Get(long id)
        {
            return _mapper.Map<CityViewModel>(await _cityCrudService.GetByIdAsync(id));
        }

        // POST api/city
        [HttpPost]
        public ActionResult<CityViewModel> Post([FromBody] CityViewModel viewModel)
        {
            var city = _mapper.Map<City>(viewModel);

            try
            {
                city.Frontier = viewModel.Frontier;
                _cityCrudService.Insert(city);
            }
            catch (Exception ex) { }

            viewModel.Id = city.Id;

            return viewModel;
        }

        // Patch api/city/5
        [HttpPatch("{id}")]
        public ActionResult<CityViewModel> Patch(long id, [FromBody] CityViewModel viewModel)
        {
            var city = _cityCrudService.Get(id);
            try
            {
                city.Name = viewModel.Name ?? city.Name;
                city.Population = viewModel.Population ?? city.Population;
                city.Frontier = viewModel.Frontier ?? city.Frontier;

                _cityCrudService.Update(city);
            }
            catch (Exception ex) { }

            return _mapper.Map<CityViewModel>(city);
        }

        // DELETE api/city/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            try
            {
                _cityCrudService.Delete(id);
            }
            catch (Exception ex) { }
        }

        // PUT api/city/5/frontier
        [HttpPut("{id}/frontier")]
        public ActionResult<CityViewModel> PutFrontier(long id, [FromBody] long[] frontier)
        {
            var city = _cityCrudService.Get(id);
            try
            {
                city.Frontier = frontier.Select(x => x.ToString()).ToArray();

                _cityCrudService.Update(city);
            }
            catch (Exception ex) { }

            return _mapper.Map<CityViewModel>(city);
        }

        // GET api/city/5/frontier
        [HttpGet("{id}/frontier")]
        public ActionResult<List<FrontierViewModel>> GetFrontier(long id)
        {
            var city = _cityCrudService.Get(id);
            var frontier = _cityCrudService.GetAllById(city.Frontier.Select(x => long.Parse(x)).ToArray());

            return _mapper.Map<List<FrontierViewModel>>(frontier);
        }

        // POST api/city/population
        [HttpPost("population")]
        public ActionResult<int> Population(long[] ids)
        {
            return _cityCrudService.SumPopulationFromCities(ids);
        }
    }
}