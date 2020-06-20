using System.ComponentModel.DataAnnotations;

namespace EZ.Knewin.Teste.Domain.Entities
{
    public abstract class Entity<TId> where TId : struct
    {
        [Key]
        public TId Id { get; set; }

        protected Entity() { }
    }
}
