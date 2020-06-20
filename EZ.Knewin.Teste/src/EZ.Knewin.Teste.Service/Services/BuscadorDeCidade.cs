using AutoMapper;
using EZ.Knewin.Teste.Domain.Interfaces;
using EZ.Knewin.Teste.Service.Dtos;
using EZ.Knewin.Teste.Service.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Service.Services
{
    public class BuscadorDeCidade : IBuscadorDeCidade
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;

        public BuscadorDeCidade(ICidadeRepository cidadeRepository, IMapper mapper)
        {
            _cidadeRepository = cidadeRepository;
            _mapper = mapper;
        }

        public async Task<IList<CidadeDto>> ObterFronteirasPorCidadeId(int id)
        {
            var cidade = await _cidadeRepository.ObterPorId(id);

            var fronteiras = await _cidadeRepository.ObterListaPorIds(JsonConvert.DeserializeObject<int[]>(cidade.FronteirasIds));

            return _mapper.Map<List<CidadeDto>>(fronteiras);
        }

        public async Task<CidadeDto> ObterPorId(int id)
        {
            var cidade = await _cidadeRepository.ObterPorId(id);
            
            return _mapper.Map<CidadeDto>(cidade);
        }

        public async Task<IList<CidadeDto>> ObterTodas()
        {
            var cidades = await _cidadeRepository.ObterTodosAsync();

            return _mapper.Map<List<CidadeDto>>(cidades);
        }

        public async Task<int> ObterTotalDeHabitantesPorCidades(int[] cidadesIds)
        {
             var total = await _cidadeRepository.ObterTotalDeHabitantesPorCidades(cidadesIds);

             return total;
        }
    }
}
