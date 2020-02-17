using Cidades.Domain.Repositories.Common;
using Cidades.Infra.Context;
using System.Threading.Tasks;

namespace Cidades.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MongoDbContext _context;

        public UnitOfWork(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var changeAmount = await _context.SaveChanges();

            return changeAmount > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
