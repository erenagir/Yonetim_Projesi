using FluentValidation;
using X.Yönetim.UI.Models.RequestModels.Goals;

namespace X.Yönetim.UI.Validators.Goals
{
    public class DeleteGoalValidator : AbstractValidator<DeleteGoalVM>
    {
        public DeleteGoalValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty()
              .WithMessage("hedef kimlik numarası boş bırakılamaz.")
              .GreaterThan(0)
              .WithMessage("hedef  kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
