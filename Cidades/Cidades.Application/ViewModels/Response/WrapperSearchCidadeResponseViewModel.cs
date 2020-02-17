using Cidades.Application.ViewModels.Common;
using System.Collections.Generic;
using System.Linq;

namespace Cidades.Application.ViewModels.Response
{
    public class WrapperSearchCidadeResponseViewModel : BaseResponseViewModel
    {
        public IEnumerable<ListCidadeResponseViewModel> List { get; set; }

        public bool NoRegisters()
        {
            return null != List ? (List.Count() < 1 ? true : false) : true;
        }
    }
}
