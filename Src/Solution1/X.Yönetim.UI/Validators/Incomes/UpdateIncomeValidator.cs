using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.UI.Models.RequestModels.Incomes;

namespace X.Yönetim.UI.Validators.Incomes
{
    public class UpdateIncomeValidator:AbstractValidator<UpdateIncomeVM>
    {
        public UpdateIncomeValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("bütçe kimlik numarası boş olamaz.")
               .GreaterThan(0).WithMessage("bütçe kimlik numarası sıfırdan büyük bir sayı olmalıdır.");

            RuleFor(x => x.UserId)
                 .NotEmpty().WithMessage("Bütçe ait kullanıcı bilgisi boş olamaz.")
                 .GreaterThan(0).WithMessage("kullanıcı bilgisi sıfırdan büyük bir sayı olmalıdır.");

            RuleFor(x => x.BudgetId)
              .NotEmpty().WithMessage("Bütçe ait kullanıcı bilgisi boş olamaz.")
              .GreaterThan(0).WithMessage("kullanıcı bilgisi sıfırdan büyük bir sayı olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Bütçe adı boş olamaz.")
                .MaximumLength(100).WithMessage("Bütçe adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("işlem miktar bilgisi boş olamaz.");

            RuleFor(x => x.TransactionDate)
                .NotEmpty().WithMessage("işlem tarih bilgisi boş olamaz.");
        }
    }
}
