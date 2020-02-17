using System;

namespace Cidades.Shared.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }
    }
}
