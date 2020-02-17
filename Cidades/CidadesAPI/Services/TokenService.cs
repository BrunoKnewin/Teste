using Cidades.Application.ViewModels.Response;
using CidadesAPI.Helpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CidadesAPI.Services
{
    public static class TokenService
    {
        public static LoginResponseViewModel GenerateToken(LoginResponseViewModel model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.UserName.ToString()),
                    new Claim(ClaimTypes.Email, model.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            model.Token = tokenHandler.WriteToken(token);
            model.DataExpiracao = DateTime.UtcNow.AddHours(2);
            return model;
        }
    }
}
