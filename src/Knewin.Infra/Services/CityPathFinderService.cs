using Knewin.Infra.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Knewin.Infra.Services
{
    public class CityPathFinderService : ICityPathFinderService
    {
        private Dictionary<long, bool> _isVisited;
        private Dictionary<long, List<long>> _adjacencyList;

        private List<long[]> _trackedPaths;

        private readonly ICityCrudService _cityCrudService;

        public CityPathFinderService(ICityCrudService cityCrudService)
        {
            _cityCrudService = cityCrudService;
        }

        private void Initialize()
        {
            _trackedPaths = new List<long[]>();
            _adjacencyList = new Dictionary<long, List<long>>();
            _isVisited = new Dictionary<long, bool>();

            var allCities = _cityCrudService.GetPage(int.MaxValue, 0);

            foreach (var city in allCities)
            {
                if (!_adjacencyList.ContainsKey(city.Id))
                    _adjacencyList[city.Id] = new List<long>();

                _isVisited[city.Id] = false;
                _adjacencyList[city.Id].AddRange(city.Frontier);
            }

        }

        private void RecursiveGetAllPaths(long from, long to, List<long> pathList)
        {
            _isVisited[from] = true;

            if (from.Equals(to))
            {
                _trackedPaths.Add(pathList.ToArray());

                _isVisited[from] = false;

                return;
            }

            foreach (int i in _adjacencyList[from])
            {
                if (!_isVisited[i])
                {
                    pathList.Add(i);
                    RecursiveGetAllPaths(i, to, pathList);

                    pathList.Remove(i);
                }
            }

            _isVisited[to] = false;
        }

        public long[] GetOnePath(long from, long to)
        {
            var pathList = new List<long>() { };

            Initialize();

            pathList.Add(from);

            RecursiveGetAllPaths(from, to, pathList);

            var maybeTheSmallerPath = _trackedPaths.First();

            _trackedPaths.ForEach(x => {
                if (x.Length < maybeTheSmallerPath.Length)
                    maybeTheSmallerPath = x;
            });

            return maybeTheSmallerPath;
        }
    }
}
