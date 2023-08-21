using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.RequestModels.Incomes;

namespace X.Yönetim.Application.Validators.Incomes
{
    public class GetIncomeByIdValidator:AbstractValidator<DeleteIncomeVM>
    {
        public GetIncomeByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("gelir kimlik numarası boş bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("gelir kimlik bilgisi sıfırdan büyük olmalıdır.");
        }
    }
}
