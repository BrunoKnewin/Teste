using System;
using System.Collections.Generic;
using System.Linq;
using cidades.Model;
using Microsoft.EntityFrameworkCore;

namespace cidades.Infrastructure.Services
{
    // baseado no sample do OpenIddict:
    // https://github.com/cornflourblue/aspnet-core-3-registration-login-api
    public class UserService
    {
        // lista hardcoded de usuários, por simplicidade
        private readonly List<User> users = new List<User>
        {
            new User(){ Id = 1, Username = "eduardo", Password = "teste"},
            new User(){ Id = 2, Username = "knewin", Password = "vagaemprego"}
        };
        public UserService()
        {
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            // aqui buscaria de uma fonte correta
            // para fins deste teste, estamos usando uma lista hardcoded
            var user = users.SingleOrDefault(x => x.Username == username);

            if (user == null)
                return null;

            // aqui também deveria verificar o hash, não a igualdade
            if (password!=user.Password)
                return null;


            return user;
        }

        internal object GetById(int userId)
        {
            return users.SingleOrDefault(u => u.Id == userId);
        }
    }
}
