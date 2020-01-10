using Knewin.Core.Entities;
using System;
using System.Collections.Generic;

namespace Knewin.Domain.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }

        public int Population { get; set; }

        public ICollection<Frontier> Frontier { get; set; }
    }
}
