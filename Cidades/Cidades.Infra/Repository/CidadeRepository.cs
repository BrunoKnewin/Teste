using Cidades.Domain.Entities;
using Cidades.Domain.Repositories;
using Cidades.Infra.Context;
using Cidades.Infra.Repository.Common;

namespace Cidades.Infra.Repository
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(MongoDbContext context) : base(context)
        {
        }
    }
}
