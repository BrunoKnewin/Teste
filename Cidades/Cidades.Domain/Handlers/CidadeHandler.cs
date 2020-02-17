using Cidades.Domain.Commands.Inputs;
using Cidades.Domain.Commands.Results.Common;
using Cidades.Domain.Entities;
using Cidades.Domain.Repositories;
using Cidades.Domain.Repositories.Common;
using Cidades.Shared.Commands;
using Cidades.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cidades.Domain.Handlers
{
    public class CidadeHandler : IHandler<CreateCidadeCommand>,
        IHandler<UpdateCidadeCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICidadeRepository _repository;

        public CidadeHandler(IUnitOfWork uow, ICidadeRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public ICommandResult Handle(CreateCidadeCommand command)
        {
            command.Validate();


            var cidade = new Cidade(command.Nome, command.Populacao, command.Fronteiras);

            _repository.Add(cidade);

            _uow.Commit();

            return new CommandResult(true, "Cidade cadastrada com sucesso!");
        }

        public ICommandResult Handle(UpdateCidadeCommand command)
        {
            command.Validate();

            var cidade = _repository.GetById(command.Id).Result;
            cidade.Update(command.Nome, command.Populacao, command.Fronteiras);

            _repository.Update(cidade);

            _uow.Commit();

            return new CommandResult(true, "Cidade atualizada com sucesso!");
        }

        public ICommandResult Handle(PopularCidadesCommand command)
        {

            foreach(var cidade in command.Cidades)
            {
                _repository.Add(cidade);
            }

            _uow.Commit();

            return new CommandResult(true, "Cidades cadastradas!");
        }
    }
}
