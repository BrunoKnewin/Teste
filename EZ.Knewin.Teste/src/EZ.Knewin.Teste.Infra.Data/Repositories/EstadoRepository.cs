using EZ.Knewin.Teste.Domain.Entities;
using EZ.Knewin.Teste.Domain.Interfaces;
using EZ.Knewin.Teste.Infra.Data.Context;

namespace EZ.Knewin.Teste.Infra.Data.Repositories
{
    public class EstadoRepository : RepositoryBase<Estado>, IEstadoRepository
    {
        private readonly TesteDbContext context;

        public EstadoRepository(TesteDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
