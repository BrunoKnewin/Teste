using System.Collections.Generic;

namespace Cidades.Application.ViewModels.Common
{
    public class BaseResponseViewModel
    {
        public BaseResponseViewModel()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }

        public bool IsValid()
        {
            return Messages.Count < 1 ? true : false;
        }
    }
}
