using AutoMapper;
using Cidades.Application.Interfaces;
using Cidades.Application.ViewModels.Request;
using Cidades.Application.ViewModels.Response;
using Cidades.Domain.Commands.Inputs;
using Cidades.Domain.Commands.Results.Common;
using Cidades.Domain.Handlers;
using Cidades.Domain.Repositories;
using System;
using System.Linq;

namespace Cidades.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserHandler _userHandler;

        public UserAppService(IMapper mapper, IUserRepository repository, UserHandler userHandler)
        {
            _repository = repository;
            _mapper = mapper;
            _userHandler = userHandler;
        }

        public LoginResponseViewModel Authenticate(LoginRequestViewModel model)
        {
            var resultReturn = new LoginResponseViewModel();
            var resultQuery = _repository.Query(x => x.Email == model.Email && x.Senha == model.Password).FirstOrDefault();
            if (null != resultQuery)
            {
                resultReturn.Email = resultQuery.Email;
                resultReturn.UserId = resultQuery.Id.ToString();
                resultReturn.UserName = resultQuery.Nome;
            }
            else
            {
                resultReturn.Messages.Add("Usuário não encontrado!");
            }
            return resultReturn;
        }

        public AddUserResponseViewModel Cadastrar(AddUserRequestViewModel model)
        {
            var result = new AddUserResponseViewModel();
            var userCommand = _mapper.Map<CreateUserCommand>(model);
            var returnCommand = (CommandResult)_userHandler.Handle(userCommand);
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
    }
}
