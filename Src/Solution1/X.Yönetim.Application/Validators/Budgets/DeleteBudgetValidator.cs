﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.RequestModels.Budgets;

namespace X.Yönetim.Application.Validators.Budgets
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
