using FluentValidation;
using X.Yönetim.UI.Models.RequestModels.UserImages;

namespace X.Yönetim.UI.Validators.UserImages
{

    public class GetUserImageValidator : AbstractValidator<GetUserImageVM>
    {
        public GetUserImageValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("kullanıcıya ait kimlik bilgisi boş bırakılamaz.")
                .GreaterThan(0).WithMessage("kullanıcıya ait kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
