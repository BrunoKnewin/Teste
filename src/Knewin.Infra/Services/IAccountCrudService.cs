using Knewin.Core.Services;
using Knewin.Domain.Entities;

namespace Knewin.Infra.Services
{
    public interface IAccountCrudService : ICrudService<Account>
    {
        Account Authenticate(string username, string password);
    }
}
