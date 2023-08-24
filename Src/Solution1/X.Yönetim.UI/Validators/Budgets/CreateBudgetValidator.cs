using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.UI.Models.RequestModels.Budgets;

namespace X.Yönetim.UI.Validators.Budgets
{
    public class CreateBudgetValidator:AbstractValidator<CreateBudgetVM>
    {
        public CreateBudgetValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("Bütçe ait kullanıcı bilgisi boş olamaz.")
                .GreaterThan(0).WithMessage("kullanıcı bilgisi sıfırdan büyük bir sayı olmalıdır.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("Bütçe adı boş olamaz.")
                .MaximumLength(50).WithMessage("Bütçe adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.StartDate)
                .NotNull().WithMessage("bütçe başlancıç bilgisi boş olamaz.");

            RuleFor(x => x.StartDate)
                .NotNull().WithMessage("bütçe bitiş bilgisi boş olamaz.");

            //RuleFor(x => x.Amount)
            //    .Must(m => decimal.TryParse(m.ToString(), out var val))
            //    .WithMessage("miktar değeri sayı olmalıdır");


        }
    }
}
