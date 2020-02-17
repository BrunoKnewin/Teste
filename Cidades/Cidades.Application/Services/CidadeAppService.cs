using AutoMapper;
using Cidades.Application.Interfaces;
using Cidades.Application.ViewModels.Request;
using Cidades.Application.ViewModels.Response;
using Cidades.Domain.Commands.Inputs;
using Cidades.Domain.Commands.Results.Common;
using Cidades.Domain.Entities;
using Cidades.Domain.Handlers;
using Cidades.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cidades.Application.Services
{
    public class CidadeAppService : ICidadeAppService
    {
        private readonly ICidadeRepository _repository;
        private readonly IMapper _mapper;
        private readonly CidadeHandler _cidadeHandler;

        public CidadeAppService(IMapper mapper, ICidadeRepository repository, CidadeHandler cidadeHandler)
        {
            _repository = repository;
            _mapper = mapper;
            _cidadeHandler = cidadeHandler;
        }

        public AddCidadeResponseViewModel Save(AddCidadeRequestViewModel model)
        {
            var result = new AddCidadeResponseViewModel();
            var cidadeCommand = _mapper.Map<CreateCidadeCommand>(model);

            var returnCommand = (CommandResult)_cidadeHandler.Handle(cidadeCommand);
            if (!returnCommand.Success)
            {
                result.Messages.Add(returnCommand.Message);
            }

            return result;
        }

        public async Task<WrapperSearchCidadeResponseViewModel> GetAll()
        {
            var result = new WrapperSearchCidadeResponseViewModel();

            var resultQuery = await _repository.GetAll();

            if (null != resultQuery && resultQuery.Count() > 0)
            {
                result.List = resultQuery.Select(x => new ListCidadeResponseViewModel
                {
                    Id = x.Id,
                    Fronteiras = x.Fronteiras,
                    Nome = x.Nome,
                    Populacao = x.Populacao
                }).AsEnumerable();
            }

            return result;
        }

        public List<string> FazemFronteirasCom(string cidade)
        {
            var result = new List<string>();

            var resultQuery = _repository.Query(x => x.Nome.ToLower().Contains(cidade.ToLower()));

            if (null != resultQuery && resultQuery.Count() > 0)
            {
                resultQuery.ToList().ForEach(x => { result.AddRange(x.Fronteiras); });
            }

            return result;

        }

        public ListCidadeResponseViewModel GetByName(string nome)
        {
            var result = new ListCidadeResponseViewModel();

            var resultQuery = _repository.Query(x => x.Nome.ToLower().Contains(nome.ToLower())).FirstOrDefault();
            if (null != resultQuery)
            {
                result.Id = resultQuery.Id;
                result.Nome = resultQuery.Nome;
                result.Populacao = resultQuery.Populacao;
                result.Fronteiras = resultQuery.Fronteiras;
            }

            return result;
        }

        public UpdateCidadeResponseViewModel Update(UpdateCidadeRequestViewModel model)
        {
            var result = new UpdateCidadeResponseViewModel();
            var cidadeCommand = _mapper.Map<UpdateCidadeCommand>(model);

            var returnCommand = (CommandResult)_cidadeHandler.Handle(cidadeCommand);
            if (!returnCommand.Success)
            {
                result.Messages.Add(returnCommand.Message);
            }

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public double CalcularPopulacao(List<string> cidades)
        {
            var populacao = _repository.Query(x => cidades.Select(y => y.ToLower()).Contains(x.Nome.ToLower())).Select(x => x.Populacao).Sum();

            return populacao;
        }

        public void PopularBanco()
        {
            List<Cidade> cidades = new List<Cidade>();
            cidades.Add(new Cidade("Salvador", 4000000, new List<string> { "Lauro de Freitas", "Simões Filho", "Candeias" }));
            cidades.Add(new Cidade("Lauro de Freitas", 1000, new List<string> { "Salvador", "Camaçari", "Candeias", "Dias D'Ávila" }));
            cidades.Add(new Cidade("Camaçari", 5000, new List<string> { "Candeias", "Lauro de Freitas", "Itacimirin" }));

            cidades.Add(new Cidade("São Paulo", 14000000, new List<string> { "Santo André", "Campinas", "Mogi das Cruzes" }));
            cidades.Add(new Cidade("Santo André", 15000, new List<string> { "São Bernardo do Campo", "Lauro de Freitas", "Itacimirin" }));
            cidades.Add(new Cidade("Campinas", 25000, new List<string> { "Americana", "Barueri" }));
            cidades.Add(new Cidade("Americana", 1000, new List<string> { "Campinas", "Paulínia" }));

            _cidadeHandler.Handle(new PopularCidadesCommand() { Cidades = cidades });
            
        }
    }
}
