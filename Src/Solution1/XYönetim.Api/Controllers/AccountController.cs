using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.Yönetim.Application.Models.Dtos.Accounts;
using X.Yönetim.Application.Models.RequestModels.Accounts;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Wrapper;

namespace XYönetim.Api.Controllers
{
    [ApiController]
    [Route("account")]
    [Authorize]
    public class AccountCountroller : ControllerBase
    {
       
        private readonly IAccountService _accountService;

        public AccountCountroller(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<int>>> Register(RegisterVM createUserVM)
        {
            var result = await _accountService.Register(createUserVM);
            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<Result<TokenDto>>> Login(LoginVM loginVM)
        {
            var result = await _accountService.Login(loginVM);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Result<int>>> UpdateUser(int? id, UpdateUserVM updateUserVM)
        {
            if (id != updateUserVM.Id)
            {
                return BadRequest();
            }
            var result = await _accountService.UpdateUser(updateUserVM);
            return Ok(result);
        }


    }
}