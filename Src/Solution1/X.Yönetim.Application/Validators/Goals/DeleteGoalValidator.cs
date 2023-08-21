using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Models.RequestModels.Expenses;
using X.Yönetim.Application.Models.RequestModels.Goals;

namespace X.Yönetim.Application.Validators.Goals
{
    public class DeleteGoalValidator : AbstractValidator<DeleteGoalVM>
    {
        public DeleteGoalValidator()
        {
            RuleFor(x => x.Id)
              .NotEmpty()
              .WithMessage("hedef kimlik numarası boş bırakılamaz.")
              .GreaterThan(0)
              .WithMessage("hedef  kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
