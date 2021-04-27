using LoginNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
namespace Login.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        [Route("RealizeLogin")]
        public string RealizaLogin(Login login)
        {
            ManipulaUsuario manipulaUsuario = new ManipulaUsuario();
            try
            {
                return manipulaUsuario.RealizaLogin(login.nome, login.senha);
            }
            catch(Exception ex) 
            {
                return $"Dados de Usuário não conferem. {ex.Message}";
            }
        }
    }
    public class Login{
        public string nome { get; set; }
        public string senha { get; set; }
    }
}