using EZ.Knewin.Teste.Service.Dtos;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Service.Interfaces
{
    public interface IAtualizadorDeCidade
    {
        Task<CidadeDto> Atualizar(CidadeDto cidadeDto);
    }
}
