using Cidades.Application.ViewModels.Request;
using Cidades.Application.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cidades.Application.Interfaces
{
    public interface ICidadeAppService : IDisposable
    {
        AddCidadeResponseViewModel Save(AddCidadeRequestViewModel model);
        Task<WrapperSearchCidadeResponseViewModel> GetAll();
        ListCidadeResponseViewModel GetByName(string nome);
        List<string> FazemFronteirasCom(string cidade);
        UpdateCidadeResponseViewModel Update(UpdateCidadeRequestViewModel request);
        double CalcularPopulacao(List<string> cidades);
        void PopularBanco();
    }
}
