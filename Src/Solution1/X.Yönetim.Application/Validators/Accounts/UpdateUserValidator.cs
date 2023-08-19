using FluentValidation;
using X.Yönetim.Application.Models.RequestModels.Accounts;

namespace X.Yönetim.Application.Validators.Accounts
{
    public class UpdateUserValidator:AbstractValidator<UpdateUserVM>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Güncellenecek kullanıcı kimlik numarası gönderilmelidir.");
          
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad bilgisi boş olamaz.")
                .MaximumLength(30).WithMessage("Ad bilgisi 30 karakterden büyük olamaz.");

            RuleFor(x => x.SurName)
                .NotEmpty().WithMessage("Soyad bilgisi boş olamaz.")
                .MaximumLength(30).WithMessage("Soyad bilgisi 30 karakterden büyük olamaz.");
           
            RuleFor(x => x.IdentityNumber)
              .NotEmpty().WithMessage("Tc kimlik boş olamaz.")
              .MaximumLength(11).WithMessage("Tc kimlik numarası 11 karakterden büyük olamaz.")
              .MinimumLength(11).WithMessage("Tc kimlik numarası 11 karakterden küçük olamaz.");
           
            
            RuleFor(x => x.Birtdate)
                  .NotEmpty().WithMessage("Doğum tarihi bilgisi boş olamaz.");

        }


    }
}
