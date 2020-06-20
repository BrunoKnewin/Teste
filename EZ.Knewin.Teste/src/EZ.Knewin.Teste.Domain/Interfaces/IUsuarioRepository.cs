using EZ.Knewin.Teste.Domain.Entities;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorUsuarioESenha(string username, string senha);
    }
}
