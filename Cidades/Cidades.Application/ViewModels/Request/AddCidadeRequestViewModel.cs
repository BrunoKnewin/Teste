using System.Collections.Generic;

namespace Cidades.Application.ViewModels.Request
{
    public class AddCidadeRequestViewModel
    {
        public string Nome { get; set; }
        public double Populacao { get; set; }
        public List<string> Fronteiras { get; set; }
    }
}
