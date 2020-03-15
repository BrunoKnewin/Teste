using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using cidades.Infrastructure.Services;
using cidades.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace cidades.Controllers
{
    // baseado no sample do OpenIddict:
    // https://github.com/cornflourblue/aspnet-core-3-registration-login-api
    [ApiController, Route("api/[controller]"), AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(UserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWT:SigningKey"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            

            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                Token = tokenString
            });
        }
    }
}