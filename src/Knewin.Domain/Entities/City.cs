using Knewin.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Knewin.Domain.Entities
{
    public class City : Entity
    {
        private static readonly char delimiter = ';';

        private string _frontier;

        public string Name { get; set; }

        public int Population { get; set; }

        [NotMapped]
        public string[] Frontier
        {
            get { return _frontier.Split(delimiter); }
            set
            {
                _frontier = string.Join($"{delimiter}", value);
            }
        }
    }
}
