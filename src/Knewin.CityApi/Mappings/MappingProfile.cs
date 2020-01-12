using Knewin.Domain.Entities;
using AutoMapper;
using Knewin.CityApi.ViewModels;

namespace Knewin.CityApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityViewModel>().ReverseMap();

            CreateMap<City, FrontierViewModel>().ReverseMap();

            CreateMap<Account, AccountViewModel>().ReverseMap();
        }
    }
}
