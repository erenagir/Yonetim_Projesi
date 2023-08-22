using FluentValidation;
using X.Yönetim.UI.Models.RequestModels.Goals;

namespace X.Yönetim.UI.Validators.Goals
{
    public class CreateGoalValidator : AbstractValidator<CreateGoalVM>
    {
        public CreateGoalValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Bütçe ait kullanıcı bilgisi boş olamaz.")
                .GreaterThan(0).WithMessage("kullanıcı bilgisi sıfırdan büyük bir sayı olmalıdır.");
            
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("hedef isim bilgisi boş olamaz.")
               .MaximumLength(50).WithMessage("Bütçe adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Bütçe adı boş olamaz.")
                .MaximumLength(100).WithMessage("Bütçe adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.TargetAmount)
                .NotEmpty().WithMessage("işlem miktar bilgisi boş olamaz.");

            RuleFor(x => x.TargetDate)
                .NotEmpty().WithMessage("işlem tarih bilgisi boş olamaz.");

          


        }
    }
}



