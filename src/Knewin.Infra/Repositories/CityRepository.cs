using Knewin.Core.Repositories;
using Knewin.Domain.Entities;
using Knewin.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knewin.Infra.Repositories
{
    public class CityRepository : EfCoreRepository<City, CityContext>, ICityRepository
    {
        public CityRepository(CityContext context) : base(context)
        {
        }
    }
}
