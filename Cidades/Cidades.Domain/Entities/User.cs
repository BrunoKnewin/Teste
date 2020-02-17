using Cidades.Shared.Entities;
using System;

namespace Cidades.Domain.Entities
{
    public class User : Entity
    {
        public User(string email, string senha, string nome, DateTime dataNascimento)
        {
            Email = email;
            Senha = senha;
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
