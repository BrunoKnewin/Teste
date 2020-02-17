using Cidades.Application.ViewModels.Request;
using Cidades.Application.ViewModels.Response;
using System;

namespace Cidades.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        LoginResponseViewModel Authenticate(LoginRequestViewModel model);
        AddUserResponseViewModel Cadastrar(AddUserRequestViewModel model);
    }
}
