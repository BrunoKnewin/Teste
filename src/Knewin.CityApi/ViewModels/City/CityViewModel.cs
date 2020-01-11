using System.ComponentModel.DataAnnotations.Schema;

namespace Knewin.CityApi.ViewModels.City
{
    public class CityViewModel
    {
        [NotMapped]
        public long Id { get; set; }

        public string Name { get; set; }

        public int? Population { get; set; }

        public string[] Frontier { get; set; }
    }
}
