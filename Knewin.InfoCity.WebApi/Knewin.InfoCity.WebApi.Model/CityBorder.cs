using System.ComponentModel.DataAnnotations.Schema;

namespace Knewin.InfoCity.WebApi.Model
{
    [Table("CitiesBorder")]
    public class CityBorder
    {
        public int Id { get; set; }
        public int CityBorderAId { get; set; }
        public int CityBorderBId { get; set; }
        public City CityBorderA { get; set; }
        public City CityBorderB { get; set; }
    }
}
