using Cidades.Application.ViewModels.Common;
using System.Collections.Generic;

namespace Cidades.Application.ViewModels.Response
{
    public class ListCidadeResponseViewModel : BaseResponseViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public double Populacao { get; set; }
        public List<string> Fronteiras { get; set; }
    }
}
