using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.Dtos.UserImages;
using X.Yönetim.Application.Models.RequestModels.UserImages;
using X.Yönetim.Application.Wrapper;

namespace X.Yönetim.Application.Services.Abstraction
{
    public interface IUserImageService
    {
        Task<Result<UserImageDto>> GetUserImage(GetUserImageVM getUserImageVM);


        Task<Result<int>> CreateUserImage(CreateUserImageVM createUserImageVM);
        Task<Result<int>> DeleteUserImage(DeleteUserImageVM deleteUserImageVM);
    }
}
