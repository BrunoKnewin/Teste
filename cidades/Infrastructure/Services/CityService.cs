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
            return _dbContext.Cities
                // sem os Include pois o retorno do List ficaria com vários MB!
                .ToList();
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

        internal string FindPath(City city, City cityTo)
        {
            return this.DepthFirstIterative(city, cityTo);
        }
        
        // Das aulas de Estrutura de Dados 1/2: DFS
        // procura em um grafo selecionando sempre, no caso, a primeira cidade vizinha
        // caso não encontre, faz o backtrack e tenta a segunda, e assim por diante
        // ligeiramente modificado da fonte: https://stackoverflow.com/a/26429707 
        private string DepthFirstIterative(City start, City endNode)
        {
            string pathCityNames = string.Empty;
            var visited = new LinkedList<City>();
            var stack = new Stack<City>();

            stack.Push(start);

            while (stack.Count != 0)
            {
                var current = stack.Pop();

                if (visited.Contains(current))
                    continue;

                visited.AddLast(current);
                // faz o Get toda vez, para garantir o Load das entidades
                // das listas que compõem a propriedade Neighbors
                var neighbors = new LinkedList<City>(this.Get(current.Id.Value).Neighbors);

                foreach (var neighbor in neighbors)
                {
                    if (visited.Contains(neighbor))
                        continue;

                    if (neighbor.Equals(endNode))
                    {
                        visited.AddLast(neighbor);
                        pathCityNames = string.Join(',',visited.Select(c => c.Name).ToList());
                        visited.RemoveLast();
                        break;
                    }
                }

                // aqui não estamos necessariamente preocupados com menor caminho
                // então se encontrou um, já retorna
                if(!string.IsNullOrEmpty(pathCityNames))
                    break;

                bool isPushed = false;
                foreach (var neighbor in neighbors.Reverse())
                {
                    if (neighbor.Equals(endNode) || visited.Contains(neighbor) || stack.Contains(neighbor))
                    {
                        continue;
                    }

                    isPushed = true;
                    stack.Push(neighbor);
                }

                if (!isPushed)
                    visited.RemoveLast();
            }
            return pathCityNames;
        }
    }
}