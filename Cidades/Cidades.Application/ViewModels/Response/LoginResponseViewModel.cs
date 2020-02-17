using Cidades.Application.ViewModels.Common;
using System;
using System.Collections.Generic;

namespace Cidades.Application.ViewModels.Response
{
    public class LoginResponseViewModel : BaseResponseViewModel
    {
        public LoginResponseViewModel()
        {
            Messages = new List<string>();
        }
        public string Email { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}
