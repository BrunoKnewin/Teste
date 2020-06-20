using EZ.Knewin.Teste.Domain.Entities;
using EZ.Knewin.Teste.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Service.Interfaces
{
    public interface IBuscadorDeCidade
    {
        Task<IList<CidadeDto>> ObterTodas();
        Task<CidadeDto> ObterPorId(int id);
        Task<IList<CidadeDto>> ObterFronteirasPorCidadeId(int id);
        Task<int> ObterTotalDeHabitantesPorCidades(int[] cidadesIds);
    }
}
