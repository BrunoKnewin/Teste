using AutoMapper;
using EZ.Knewin.Teste.Domain.Entities;
using EZ.Knewin.Teste.Domain.Interfaces;
using EZ.Knewin.Teste.Service.Dtos;
using EZ.Knewin.Teste.Service.Interfaces;
using Newtonsoft.Json;

namespace EZ.Knewin.Teste.Service.Services
{
    public class AtualizadorDeCidade : IAtualizadorDeCidade
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;

        public AtualizadorDeCidade(ICidadeRepository cidadeRepository, IMapper mapper)
        {
            _cidadeRepository = cidadeRepository;
            _mapper = mapper;
        }

        public CidadeDto Atualizar(CidadeDto cidadeDto)
        {
            var cidade = _mapper.Map<Cidade>(cidadeDto);
            if (cidadeDto.FronteirasIds != null)
                cidade.AlterarFronteiras(JsonConvert.SerializeObject(cidadeDto.FronteirasIds));

            cidade =  _cidadeRepository.Atualizar(cidade);

            _cidadeRepository.SaveChanges();

            return _mapper.Map<CidadeDto>(cidade);
        }
    }
}
