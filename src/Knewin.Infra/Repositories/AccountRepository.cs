using Knewin.Core.Repositories;
using Knewin.Domain.Entities;
using Knewin.Infra.Data.Contexts;
using Knewin.Infra.Repositories.Interfaces;

namespace Knewin.Infra.Repositories
{
    public class AccountRepository : EfCoreRepository<Account, CityContext>, IAccountRepository
    {
        public AccountRepository(CityContext context) : base(context)
        {
        }
    }
}
