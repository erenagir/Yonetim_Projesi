﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Models.RequestModels.Expenses;

namespace X.Yönetim.Application.Validators.Budgets
{
    public class CreateExpenseValidator:AbstractValidator<CreateExpenseVM>
    {
        public CreateExpenseValidator()
        {
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
