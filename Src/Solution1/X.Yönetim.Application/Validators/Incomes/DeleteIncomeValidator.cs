using FluentValidation;
using X.Yönetim.Application.Models.RequestModels.Incomes;

namespace X.Yönetim.Application.Validators.Incomes
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
