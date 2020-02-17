using Cidades.Shared.Commands;
using System.Collections.Generic;

namespace Cidades.Domain.Commands.Inputs
{
    public class CreateCidadeCommand : ICommand
    {
        public CreateCidadeCommand(string nome, double populacao, List<string> fronteiras)
        {
            Nome = nome;
            Populacao = populacao;
            Fronteiras = fronteiras;
        }

        public string Nome { get; set; }
        public double Populacao { get; set; }
        public List<string> Fronteiras { get; set; }

        public void Validate()
        {

        }
    }
}
