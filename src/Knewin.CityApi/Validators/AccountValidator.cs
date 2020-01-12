using FluentValidation;
using Knewin.CityApi.ViewModels;

namespace Knewin.CityApi.Validators
{
    public class AccountValidator : AbstractValidator<AccountViewModel>
    {
        public AccountValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(e => e.Password)
                .NotEmpty()
                .Length(8, 20);
        }
    }
}
