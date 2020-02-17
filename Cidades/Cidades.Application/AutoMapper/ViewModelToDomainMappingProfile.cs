using AutoMapper;
using Cidades.Application.ViewModels.Request;
using Cidades.Domain.Commands.Inputs;
using System.Linq;

namespace Cidades.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AddCidadeRequestViewModel, CreateCidadeCommand>()
                .ConstructUsing(c => new CreateCidadeCommand(c.Nome, c.Populacao, c.Fronteiras.ToList()));

            CreateMap<AddUserRequestViewModel, CreateUserCommand>()
                .ConstructUsing(c => new CreateUserCommand(c.Email, c.Senha, c.Nome, c.DataNascimento));

            CreateMap<UpdateCidadeRequestViewModel, UpdateCidadeCommand>()
                .ConstructUsing(c => new UpdateCidadeCommand(c.Id, c.Nome, c.Populacao, c.Fronteiras));
        }
    }
}
