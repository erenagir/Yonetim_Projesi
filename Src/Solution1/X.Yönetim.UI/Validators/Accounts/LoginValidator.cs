using FluentValidation;
using X.Yönetim.UI.Models.RequestModels.Accounts;

namespace X.Yönetim.UI.Validators.Accounts
{
    public class LoginValidator:AbstractValidator<LoginVM>
    {
        public LoginValidator()
        {

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .MaximumLength(10).WithMessage("Kullanıcı adı en fazla 10 karakter olabilir.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parola boş olamaz.")
                .MaximumLength(10).WithMessage("Parola en fazla 10 karakter olabilir.");

        }
    }
}
