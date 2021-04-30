using Knewin.InfoCity.WebApi.Dal;
using Knewin.InfoCity.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Knewin.InfoCity.WebApi.Service
{
    public class CityService
    {
        private DataContext dataContext;
        public CityService()
        {
            dataContext = new DataContext();
        }

        public List<City> FindAll()
        {
            List<City> allCities;
            try
            {

                allCities = dataContext.Cities.ToList();
            }
            catch (Exception ex)
            {

                allCities = null;
            }
            return allCities;
        }
        public City FindByName(string name)
        {
            City city;
            try
            {
                city = dataContext.Cities.Where(c => c.Name == name).FirstOrDefault();
            }
            catch (Exception)
            {

                city = null;
            }

            return city;
        }
        public List<string> FindBordersName(string name)
        {
            List<string> bordersName = null;
            if (Exist(name))
            {
                bordersName = new List<string>();
                City city = FindByName(name);
                List<CityBorder> borders = FindBorder(city.Id);
                foreach (var cityBorder in borders)
                {
                    if (city.Id == cityBorder.CityBorderAId)
                        bordersName.Add(FindById(cityBorder.CityBorderBId).Name);
                    if (city.Id == cityBorder.CityBorderBId)
                        bordersName.Add(FindById(cityBorder.CityBorderAId).Name);
                }
            }
            return bordersName;
        }
        public int FindTotalPopulationGroup(List<string> citiesName)
        {
            int total = 0;
            foreach (var cityName in citiesName)
            {
                if (Exist(cityName))
                    total += FindByName(cityName).Population;
            }

            return total;
        }
        public string Create(string name, int population, List<string> cityBorders)
        {
            
                City city = null;

                if (!Exist(name))
                {
                    city = Save(name, population);

                    if (cityBorders.Count > 0)
                    {
                        foreach (var cityBorderName in cityBorders)
                        {
                        City cityborder;
                        if (!Exist(cityBorderName))
                            {
                                cityborder = Save(cityBorderName, 0);
                                SaveBorder(city.Id, cityborder.Id);
                            }
                            else
                            {
                                cityborder = FindByName(cityBorderName);
                                SaveBorder(city.Id, cityborder.Id);
                            }
                        }
                    }
                    return "Cidade '" + name + "' criada com sucesso";
                    
                }
                else
                {
                    return "Cidade '" + name + "' já foi cadastrada";
                }
        }
        public string Update(string name, string newName, int population, List<string> citiesBorderName = null)
        {
            if (Exist(name))
            {
                City city = FindByName(name);
                if (!newName.Equals("") && !name.Equals(newName))
                    city.Name = newName;
                if (population > 0)
                    city.Population = population;

                try
                {
                    dataContext.Entry(city).State = EntityState.Modified;
                    dataContext.SaveChanges();
                    if (citiesBorderName != null)
                        UpdateBorders(city.Name, citiesBorderName);

                }
                catch (Exception ex)
                {

                    return "Erro ao tentar atualizar cidade";
                }
            }
            return "Cidade atualizada com sucesso";
        }





        private City FindById(int cityBorderBId)
        {
            City city;
            try
            {
                city = dataContext.Cities.FirstOrDefault(c => c.Id == cityBorderBId);
            }
            catch (Exception)
            {

                city = null;
            }

            return city;
        }
        private List<CityBorder> FindBorder(int id)
        {
            try
            {
                return dataContext.CityBorders.Where(cb => cb.CityBorderAId == id || cb.CityBorderBId == id).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        private City Save(string name, int population)
        {
            City city = new City()
            {
                Name = name,
                Population = population
            };
            dataContext.Entry(city).State = EntityState.Added;
            dataContext.SaveChanges();
            return city;
        }
        private bool Exist(string name)
        {
            try
            {
                return dataContext.Cities.FirstOrDefault(c => c.Name == name) != null ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void SaveBorder(int cityId, int cityBorderId)
        {
            if (!ExistBorder(cityId, cityBorderId))
            {
                CityBorder cityBorder = new CityBorder()
                {
                    CityBorderAId = cityId,
                    CityBorderBId = cityBorderId
                };

                try
                {
                    dataContext.Entry(cityBorder).State = EntityState.Added;
                    dataContext.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
        private bool ExistBorder(int borderAId, int borderBId)
        {
            bool border = false;
            if (FindBorderByCities(borderAId, borderBId) != null)
                border = true;
            if (FindBorderByCities(borderBId, borderAId) != null)
                border = true;
            return border;
        }

        private CityBorder FindBorderByCities(int borderAId, int borderBId)
        {

            try
            {
                return dataContext.CityBorders.Where(cb => cb.CityBorderAId == borderAId && cb.CityBorderBId == borderBId).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
        }

        private void UpdateBorders(string name, List<string> bordersNames)
        {
            if (Exist(name) && bordersNames != null)
            {
                City city = FindByName(name);
                //RemoveBorders(city.Id);

                foreach (var borderName in bordersNames)
                {
                    if (Exist(borderName) && !ExistBorder(city.Id, FindByName(borderName).Id))
                    {
                        SaveBorder(city.Id, FindByName(borderName).Id);
                    }
                }
            }
        }
    }
}
