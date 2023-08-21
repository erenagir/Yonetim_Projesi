using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Application.Models.Dtos.Expenses;
using X.Yönetim.Application.Models.Dtos.Incomes;
using X.Yönetim.Application.Models.Dtos.UserImages;
using X.Yönetim.Application.Models.RequestModels.Accounts;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Models.RequestModels.Expenses;
using X.Yönetim.Application.Models.RequestModels.Incomes;
using X.Yönetim.Application.Models.RequestModels.UserImages;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Services.Implementation;
using X.Yönetim.Application.Wrapper;

namespace XYönetim.Api.Controllers
{
    [ApiController]
    [Route("userımage")]
    //[Authorize]
    public class UserImageController : ControllerBase
    {

        private readonly IUserImageService _userImageService;

        public UserImageController(IUserImageService userImageService)
        {
            _userImageService = userImageService;
        }

        [HttpGet("get/{id:int?}")]
        public async Task<ActionResult<Result<UserImageDto>>> GetAllImage(int? id)
        {
            var result = await _userImageService.GetUserImage(new GetUserImageVM { UserId = id });
            return Ok(result);
        }

        //[HttpGet("get/{id:int}")]
        //public async Task<ActionResult<Result<ExpenseDto>>> GetIncomeById(int id)
        //{
        //    var result = await _incomeService.GetIncomeById(new GetIncomeByIdVM { Id=id});
        //    return Ok(result);
        //}

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateUserImage([FromForm]CreateUserImageVM createUserImageVM)
        {
            var result = await _userImageService.CreateUserImage(createUserImageVM);
            return Ok(result);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteIncome(int id)
        {
            var result = await _userImageService.DeleteUserImage(new DeleteUserImageVM { Id = id });
            return Ok(result);
        }
    }
}