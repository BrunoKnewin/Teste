using Cidades.Shared.Commands;
using System;

namespace Cidades.Domain.Commands.Inputs
{
    public class UpdateUserCommand : ICommand
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
