using FluentValidation;
using X.Yönetim.UI.Models.RequestModels.Incomes;

namespace X.Yönetim.UI.Validators.Incomes
{
    internal class DeleteIncomeValidator:AbstractValidator<DeleteIncomeVM>
    {
        public DeleteIncomeValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("gelir kimlik numarası boş bırakılamaz.")
               .GreaterThan(0)
               .WithMessage("gelir kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
