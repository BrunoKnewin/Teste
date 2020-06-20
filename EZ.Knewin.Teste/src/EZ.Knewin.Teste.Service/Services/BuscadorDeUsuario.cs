using EZ.Knewin.Teste.Domain.Interfaces;
using EZ.Knewin.Teste.Service.Config;
using EZ.Knewin.Teste.Service.Dtos;
using EZ.Knewin.Teste.Service.Interfaces;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Service.Services
{
    public class BuscadorDeUsuario : IBuscadorDeUsuario
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public BuscadorDeUsuario(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto> ObterUsuarioPorCredenciais(string nomeDoUsuario, string senha)
        {
            var usuario = await _usuarioRepository.ObterPorUsuarioESenha(nomeDoUsuario, senha);

            if (usuario == null) return null;

            var token = TokenService.GenerateToken(usuario);

            return new UsuarioDto
            {
                Mensagem = "Use o token nas próximas requisições via Authorization.",
                Role = usuario.Perfil,
                Username = usuario.Username,
                Token = token
            };
        }
    }
}
