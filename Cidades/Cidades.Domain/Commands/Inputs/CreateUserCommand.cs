using Cidades.Shared.Commands;
using System;

namespace Cidades.Domain.Commands.Inputs
{
    public class CreateUserCommand : ICommand
    {
        public CreateUserCommand(string email, string senha, string nome, DateTime dataNascimento)
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

        public void Validate()
        {

        }
    }
}
