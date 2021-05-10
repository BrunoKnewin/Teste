using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Knewin.InfoCity.WebApi.Model
{
    [Table("Cities")]

    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        public int Population { get; set; }
        public List<CityBorder> CityBoders { get; set; }
    }
}
