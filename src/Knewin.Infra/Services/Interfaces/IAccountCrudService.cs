using Knewin.Core.Services;
using Knewin.Domain.Entities;

namespace Knewin.Infra.Services.Interfaces
{
    public interface IAccountCrudService : ICrudService<Account>
    {
        Account Authenticate(string email, string password);
    }
}
