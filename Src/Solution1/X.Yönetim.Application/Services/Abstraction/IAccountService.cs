using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.RequestModels;
using X.Yönetim.Application.Wrapper;

namespace X.Yönetim.Application.Services.Abstraction
{
    public class IAccountService
    {

        Task<Result<int>> Register(RegisterVM registerVM);
    }
}
