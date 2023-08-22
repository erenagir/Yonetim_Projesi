using FluentValidation;
using X.Yönetim.UI.Models.RequestModels.Goals;

namespace X.Yönetim.UI.Validators.Goals
{
    public class GetGoalByIdValidator : AbstractValidator<GetGoalByIdVM>
    {
        public GetGoalByIdValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("hedef kimlik numarası boş bırakılamaz.")
               .GreaterThan(0)
               .WithMessage("hedef kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
