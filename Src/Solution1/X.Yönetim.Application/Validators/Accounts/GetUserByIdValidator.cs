using FluentValidation;
using X.Yönetim.Application.Models.RequestModels.Accounts;

namespace X.Yönetim.Application.Validators.Accounts
{
    public class GetUserByIdValidator : AbstractValidator<GetUserbyIdVM>
    {
        public GetUserByIdValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage(" kullanıcı kimlik numarası gönderilmelidir.");
          
           

        }


    }
}
