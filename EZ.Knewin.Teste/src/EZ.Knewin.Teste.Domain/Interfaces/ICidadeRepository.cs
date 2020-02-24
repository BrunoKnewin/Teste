using EZ.Knewin.Teste.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Domain.Interfaces
{
    public interface ICidadeRepository : IRepositoryBase<Cidade>
    {
        Task<Cidade> ObterPorNome(string nome);
        Task<Cidade> ObterPorId(int id);
        Task<ICollection<Cidade>> ObterListaPorIds(int[] ids);
        Task<ICollection<Cidade>> ObterCidadesProximas(int cidadeId);
        Task<int> ObterTotalDeHabitantesPorCidades(int[] ids);
    }
}
