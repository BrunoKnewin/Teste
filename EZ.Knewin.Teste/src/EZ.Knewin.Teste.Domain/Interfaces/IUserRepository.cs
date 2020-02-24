using EZ.Knewin.Teste.Domain.Entities;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> ObterPorUsuarioESenha(string username, string senha);
    }
}
