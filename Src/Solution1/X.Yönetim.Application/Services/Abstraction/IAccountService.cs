using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.Dtos.Accounts;
using X.Yönetim.Application.Models.RequestModels.Accounts;
using X.Yönetim.Application.Wrapper;

namespace X.Yönetim.Application.Services.Abstraction
{
    public interface IAccountService
    {

        Task<Result<bool>> Register(RegisterVM registerVM);
        Task<Result<TokenDto>> Login(LoginVM loginVM);
        Task<Result<int>> UpdateUser(UpdateUserVM updateUserVM);
    }
}
