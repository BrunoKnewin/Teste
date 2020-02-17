using Cidades.Domain.Entities;
using Cidades.Domain.Repositories;
using Cidades.Infra.Context;
using Cidades.Infra.Repository.Common;

namespace Cidades.Infra.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MongoDbContext context) : base(context)
        {
        }
    }
}
