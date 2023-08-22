using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.UI.Models.RequestModels.Budgets;
using X.Yönetim.UI.Models.RequestModels.Expenses;

namespace X.Yönetim.UI.Validators.Expenses
{
    public class GetExpenseByValidator:AbstractValidator<GetExpenseByIdVM>
    {
        public GetExpenseByValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("bütçe kimlik numarası boş bırakılamaz.")
               .GreaterThan(0)
               .WithMessage("bütçe kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
