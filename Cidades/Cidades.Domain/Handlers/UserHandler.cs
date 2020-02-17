using Cidades.Domain.Commands.Inputs;
using Cidades.Domain.Commands.Results.Common;
using Cidades.Domain.Entities;
using Cidades.Domain.Repositories;
using Cidades.Domain.Repositories.Common;
using Cidades.Shared.Commands;
using Cidades.Shared.Handlers;
using System.Linq;

namespace Cidades.Domain.Handlers
{
    public class UserHandler : IHandler<CreateUserCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _repository;

        public UserHandler(IUnitOfWork uow, IUserRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            command.Validate();

            var userExistente = _repository.Query(x => x.Email.ToLower() == command.Email).FirstOrDefault();

            if (null != userExistente)
            {
                return new CommandResult(false, "Já existe um usuário cadastrado com o email informado!");
            }

            var user = new User(command.Email, command.Senha, command.Nome, command.DataNascimento);

            _repository.Add(user);

            _uow.Commit();

            return new CommandResult(true, "Usuário cadastrado com sucesso!");
        }
    }
}
