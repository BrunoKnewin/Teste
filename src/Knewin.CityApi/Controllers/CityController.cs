using AutoMapper;
using Knewin.CityApi.ViewModels;
using Knewin.Domain.Entities;
using Knewin.Infra.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Knewin.CityApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]"), ApiVersion("1")]
    public class CityController : Controller
    {
        private readonly IMapper _mapper;

        private readonly ICityCrudService _cityCrudService;

        private readonly ICityPathFinderService _cityPathFinderService;

        public CityController(IMapper mapper, ICityCrudService cityCrudService, ICityPathFinderService cityPathFinderService)
        {
            _mapper = mapper;
            _cityCrudService = cityCrudService;
            _cityPathFinderService = cityPathFinderService;
        }

        // GET api/city
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CityViewModel>> All()
        {
            return _mapper.Map<List<CityViewModel>>(_cityCrudService.GetPage(int.MaxValue, 0));
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = _mapper.Map<City>(viewModel);

            city.Frontier = viewModel.Frontier;
            _cityCrudService.Insert(city);

            viewModel.Id = city.Id;

            return viewModel;
        }

        // Patch api/city/5
        [HttpPatch("{id}")]
        public ActionResult<CityViewModel> Patch(long id, [FromBody] CityViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = _cityCrudService.Get(id);

            city.Name = viewModel.Name ?? city.Name;
            city.Population = viewModel.Population ?? city.Population;
            city.Frontier = viewModel.Frontier ?? city.Frontier;

            _cityCrudService.Update(city);

            return _mapper.Map<CityViewModel>(city);
        }

        // DELETE api/city/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _cityCrudService.Delete(id);
        }

        // GET api/city/5/frontier
        [HttpGet("{id}/frontier")]
        public ActionResult<List<FrontierViewModel>> GetFrontier(long id)
        {
            var city = _cityCrudService.Get(id);

            var frontier = _cityCrudService.GetAllById(city.Frontier);

            return _mapper.Map<List<FrontierViewModel>>(frontier);
        }

        // POST api/city/population
        [HttpPost("population")]
        public ActionResult<int> Population(long[] ids)
        {
            return _cityCrudService.SumPopulationFromCities(ids);
        }

        // GET api/city/path/1/2
        [HttpGet("path/{from}/{to}")]
        public ActionResult<long[]> Path(long from, long to)
        {
            return _cityPathFinderService.GetOnePath(from, to);
        }
    }
}