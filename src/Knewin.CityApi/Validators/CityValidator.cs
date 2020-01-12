using FluentValidation;
using Knewin.CityApi.ViewModels;
using Knewin.Infra.Services.Interfaces;

namespace Knewin.CityApi.Validators
{
    public class CityValidator : AbstractValidator<CityViewModel>
    {

        public CityValidator(ICityCrudService cityCrudService)
        {
            RuleFor(e => e.Name).NotEmpty();

            RuleFor(e => e.Population).NotEmpty();

            RuleFor(e => e.Frontier)
                .NotNull()
                .Must(cityCrudService.AllCitiesExists)
                .WithMessage("All frontier cities must be a valid city previously created.");
        }
    }
}
