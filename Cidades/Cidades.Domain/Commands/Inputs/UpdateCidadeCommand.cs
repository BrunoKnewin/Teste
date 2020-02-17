using Cidades.Shared.Commands;
using System.Collections.Generic;

namespace Cidades.Domain.Commands.Inputs
{
    public class UpdateCidadeCommand : ICommand
    {
        public UpdateCidadeCommand(string id, string nome, double populacao, List<string> fronteiras)
        {
            Id = id;
            Nome = nome;
            Populacao = populacao;
            Fronteiras = fronteiras;
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public double Populacao { get; set; }
        public List<string> Fronteiras { get; set; }

        public void Validate()
        {

        }
    }
}
