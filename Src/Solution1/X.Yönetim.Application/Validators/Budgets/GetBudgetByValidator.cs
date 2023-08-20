using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.RequestModels.Budgets;

namespace X.Yönetim.Application.Validators.Budgets
{
    public class GetBudgetByValidator:AbstractValidator<GetBudgetByIdVM>
    {
        public GetBudgetByValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("bütçe kimlik numarası boş bırakılamaz.")
               .GreaterThan(0)
               .WithMessage("bütçe kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
