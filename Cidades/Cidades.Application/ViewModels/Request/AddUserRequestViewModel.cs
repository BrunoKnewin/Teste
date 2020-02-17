using System;

namespace Cidades.Application.ViewModels.Request
{
    public class AddUserRequestViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
