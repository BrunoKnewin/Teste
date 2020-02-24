using EZ.Knewin.Teste.Domain.Entities;
using EZ.Knewin.Teste.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Service.Interfaces
{
    public interface IBuscadorDeEstado
    {
        Task<List<EstadoDto>> BuscarTodos();
    }
}
