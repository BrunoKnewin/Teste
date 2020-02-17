using Cidades.Domain.Entities;
using Cidades.Shared.Commands;
using System.Collections.Generic;

namespace Cidades.Domain.Commands.Inputs
{
    public class PopularCidadesCommand : ICommand
    {
        public List<Cidade> Cidades { get; set; }
    }
}
