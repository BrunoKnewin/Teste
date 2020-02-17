using System;
using System.Threading.Tasks;

namespace Cidades.Domain.Repositories.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
