using EZ.Knewin.Teste.Service.Dtos;
using EZ.Knewin.Teste.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Api.Controllers
{
    [Route("api/account")]
    public class LoginController : Controller
    {

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UsuarioDto>> Authenticate([FromServices] IBuscadorDeUsuario buscadorDeUsuario, [FromBody] LoginDto login)
        {
            var usuario = await buscadorDeUsuario.ObterUsuarioPorCredenciais(login.NomeDoUsuario, login.Senha);

            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            return Ok(usuario);
        }
    }
}
