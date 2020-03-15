using System;
using System.Collections.Generic;
using System.Linq;
using cidades.Model;
using Microsoft.EntityFrameworkCore;

namespace cidades.Infrastructure.Services
{
    public class CityService
    {
        private readonly CityDbContext _dbContext;
        public CityService(CityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal void Create(City city)
        {
            _dbContext.Cities.Add(city);
            _dbContext.SaveChanges();
        }

        internal City Get(int id)
        {
            return _dbContext.Cities
                .Include(c => c.CityRoutes)
                .ThenInclude(cr => cr.CityTo)
                .Include(c => c.CityRoutesFrom)
                .ThenInclude(cr => cr.City)
                .FirstOrDefault(c => c.Id == id);
        }

        internal void Update(int id, City city)
        {
            City cityDb = this.Get(id);
                
            if(!string.IsNullOrEmpty(city.Name))
                cityDb.Name = city.Name;
            if(city.Population > 0)
                cityDb.Population = city.Population;
            if(!string.IsNullOrEmpty(city.CountryState))
                cityDb.CountryState = city.CountryState;
            _dbContext.Cities.Update(cityDb);
            _dbContext.SaveChanges();
        }

        internal List<City> List()
        {
            return _dbContext.Cities.ToList();
        }

        internal City Find(string name, string countryState)
        {
            return _dbContext.Cities.FirstOrDefault(c => c.Name == name && c.CountryState == countryState);
        }

        internal List<City> GetCities(string idList)
        {
            List<int> idIntList = idList
            .Split(',',StringSplitOptions.RemoveEmptyEntries)
            .Select(id => int.Parse(id))
            .ToList();
            return _dbContext.Cities.Where(c => idIntList.Contains(c.Id.Value)).ToList();
        }
    }
}