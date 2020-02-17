using Cidades.Shared.Entities;
using System.Collections.Generic;

namespace Cidades.Domain.Entities
{
    public class Cidade : Entity
    {
        public Cidade(string nome, double populacao, List<string> fronteiras)
        {
            Nome = nome;
            Populacao = populacao;
            Fronteiras = fronteiras;
        }

        public void Update(string nome, double populacao, List<string> fronteiras)
        {
            Nome = nome;
            Populacao = populacao;
            Fronteiras = fronteiras;
        }

        public string Nome { get; set; }
        public double Populacao { get; set; }
        public List<string> Fronteiras { get; set; }
    }
}
