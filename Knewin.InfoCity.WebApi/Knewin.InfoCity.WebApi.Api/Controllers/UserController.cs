using Knewin.InfoCity.WebApi.Infrastructure;
using Knewin.InfoCity.WebApi.Model;
using Knewin.InfoCity.WebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Knewin.InfoCity.WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService userService = null;
        public UserController()
        {
            userService = new UserService();
        }
        /// <summary>
        /// Faz a autenticação de usuário para acesso as requisições da api
        /// </summary>
        /// <param name="user">Nome e senha de usuário</param>
        /// <returns>Mensagem informando erro de autenticação</returns>
        /// <returns>Dados de usuário e token de authenticação</returns>
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] User user)
        {
            User authUser = userService.Find(user.Name, user.Password);

            if (authUser == null)
                return NotFound(new { message = "ERRO! Nome de usuário e ou senha inválido(s)" });

            var token = TokenManager.GenerationToken(user);
            return new
            {
                user = authUser,
                token = token
            };
        }
    }
}
