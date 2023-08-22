using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.UI.Models.RequestModels.Budgets;

namespace X.Yönetim.UI.Validators.Budgets
{
    public class UpdatebudgetValidator : AbstractValidator<UpdateBudgetVM>
    {
        public UpdatebudgetValidator()
        {

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("bütçe kimlik numarası boş olamaz.")
                .GreaterThan(0).WithMessage("bütçe kimlik numarası sıfırdan büyük bir sayı olmalıdır.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("bütçe ait kullanıcı bilgisi boş olamaz.")
                .GreaterThan(0).WithMessage("bütçe bilgisi sıfırdan büyük bir sayı olmalıdır.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Bütçe adı boş olamaz.")
                .MaximumLength(50).WithMessage("Bütçe adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("bütçe başlancıç bilgisi boş olamaz.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("bütçe bitiş bilgisi boş olamaz.");



        }
    }
}
