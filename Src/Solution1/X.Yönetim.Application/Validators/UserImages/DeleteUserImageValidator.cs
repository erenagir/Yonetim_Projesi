using FluentValidation;
using X.Yönetim.Application.Models.RequestModels.UserImages;

namespace X.Yönetim.Application.Validators.UserImages
{

    public class DeleteUserImageValidator : AbstractValidator<DeleteUserImageVM>
    {
        public DeleteUserImageValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Silinecek kullanıcı resmine ait kimlik bilgisi boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Silinecek kullanıcı resmi kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
