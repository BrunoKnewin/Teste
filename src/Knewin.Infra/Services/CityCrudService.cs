using Knewin.Core.Services;
using Knewin.Domain.Entities;
using Knewin.Infra.Repositories;
using System;
using System.Linq;

namespace Knewin.Infra.Services
{
    public class CityCrudService : CrudService<City>, ICityCrudService
    {
        private readonly ICityRepository _cityRepository;

        public CityCrudService(ICityRepository repository) 
            : base(repository)
        {
            _cityRepository = repository;
        }

        public override bool CanDelete(long id)
            => true;

        public int SumPopulationFromCities(long[] ids)
            => _cityRepository.GetAll().Where(x => ids.Contains(x.Id)).Sum(x => x.Population);
    }
}
