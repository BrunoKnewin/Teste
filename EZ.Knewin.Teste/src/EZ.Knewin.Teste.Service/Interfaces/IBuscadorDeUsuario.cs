using EZ.Knewin.Teste.Service.Dtos;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Service.Interfaces
{
    public interface IBuscadorDeUsuario
    {
        Task<UsuarioDto> ObterUsuarioPorCredenciais(string nomeDoUsuario, string senha);
    }
}
