using Knewin.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knewin.Domain.Entities
{
    public class Frontier : Entity
    {
        public Guid CityId { get; set; }

        public Guid FrontierCityId { get; set; }

        public virtual City City { get; set; }

        public virtual City FrontierCity { get; set; }
    }
}
