using Knewin.Core.Extensions;
using Knewin.Core.Services;
using Knewin.Domain.Entities;
using Knewin.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Knewin.Infra.Services
{
    public class AccountCrudService : CrudService<Account>, IAccountCrudService
    {
        private readonly IConfiguration _configuration;

        private readonly IAccountRepository _accountRepository;

        public AccountCrudService(IAccountRepository repository, IConfiguration configuration) 
            : base(repository)
        {
            _configuration = configuration;
            _accountRepository = repository;
        }

        public Account Authenticate(string email, string password)
        {
            var account = _accountRepository.GetAll()
                .SingleOrDefault(x => x.Email == email && x.Password == password.HashPassword());

            if (account == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSecretKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, account.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            account.Token = tokenHandler.WriteToken(token);

            account.Password = null;

            return account;
        }

        public override bool CanDelete(long id)
        {
            return false;
        }
    }
}
