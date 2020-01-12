using Knewin.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Knewin.Domain.Entities
{
    public class City : Entity
    {
        private static readonly char delimiter = ';';

        private string _frontier;

        public string Name { get; set; }

        public int Population { get; set; }

        [NotMapped]
        public long[] Frontier
        {
            get {
                if (string.IsNullOrEmpty(_frontier)) return new long[] { }; 
                return _frontier.Split(delimiter).ToList().Select(x => long.Parse(x)).ToArray(); 
            }
            set
            {
                _frontier = string.Join($"{delimiter}", value);
            }
        }
    }
}
