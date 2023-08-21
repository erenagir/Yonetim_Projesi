using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Models.RequestModels.Expenses;

namespace X.Yönetim.Application.Validators.Budgets
{
    public class DeleteExpenseValidator:AbstractValidator<DeleteExpenseVM>
    {
        public DeleteExpenseValidator()
        {
            RuleFor(x=>x.Id)
                .NotEmpty().WithMessage("id bilgisi boş olamaz");
        }
    }
}
