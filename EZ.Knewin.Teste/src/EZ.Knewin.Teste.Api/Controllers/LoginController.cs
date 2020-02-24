using EZ.Knewin.Teste.Domain.Entities;
using EZ.Knewin.Teste.Service.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Api.Controllers
{
    [Route("api/account")]
    public class LoginController : Controller
    {

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            // Recupera o usuário
            var user = new User("admin", "admin", "manager"); // UserRepository.Get(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.AlterarPassword("");

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}
