using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using X.Yönetim.UI.Models.RequestModels.Budgets;

namespace X.Yönetim.UI.Validators.Budgets
{
    public class DeleteBudgetValidator:AbstractValidator<DeleteBudgetVM>
    {
        public DeleteBudgetValidator()
        {
            RuleFor(x=>x.Id)
                .NotEmpty().WithMessage("id bilgisi boş olamaz");
        }
    }
}
