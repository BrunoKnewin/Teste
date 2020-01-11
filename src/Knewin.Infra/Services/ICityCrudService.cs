using Knewin.Core.Services;
using Knewin.Domain.Entities;
using System;

namespace Knewin.Infra.Services
{
    public interface ICityCrudService : ICrudService<City>
    {
        int SumPopulationFromCities(long[] ids);
    }
}
