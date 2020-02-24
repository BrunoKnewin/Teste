using AutoMapper;
using EZ.Knewin.Teste.Domain.Interfaces;
using EZ.Knewin.Teste.Service.Dtos;
using EZ.Knewin.Teste.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Service.Services
{
    public class BuscadorDeEstado : IBuscadorDeEstado
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IMapper _mapper;

        public BuscadorDeEstado(IEstadoRepository estadoRepository, IMapper mapper)
        {
            _estadoRepository = estadoRepository;
            _mapper = mapper;
        }

        public async Task<List<EstadoDto>> BuscarTodos()
        {
            var estados = await _estadoRepository.ObterTodosAsync();

            return _mapper.Map<List<EstadoDto>>(estados);
        }
    }
}
