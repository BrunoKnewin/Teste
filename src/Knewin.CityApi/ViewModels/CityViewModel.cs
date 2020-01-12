using System.ComponentModel.DataAnnotations.Schema;

namespace Knewin.CityApi.ViewModels
{
    public class CityViewModel
    {
        [NotMapped]
        public long Id { get; set; }

        public string Name { get; set; }

        public int? Population { get; set; }

        public long[] Frontier { get; set; }
    }
}
