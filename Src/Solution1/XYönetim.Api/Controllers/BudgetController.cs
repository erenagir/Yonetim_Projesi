using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Application.Models.RequestModels.Accounts;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Wrapper;

namespace XYönetim.Api.Controllers
{
    [ApiController]
    [Route("budget")]
    [Authorize(Roles = "Admin")]
    public class BudgetController : ControllerBase
    {

        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }



        [HttpGet("get")]
        public async Task<ActionResult<Result<List<BudgetDto>>>> GetAllBudgets()
        {
            var result = await _budgetService.GetAllBudgets();
            return Ok(result);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<BudgetDto>>> GetBudgetById(int id)
        {
            var result = await _budgetService.GetBudgetById(new GetBudgetByIdVM { Id=id});
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateBudget(CreateBudgetVM createBudgetVM)
        {
            var result = await _budgetService.CreateBudget(createBudgetVM);
            return Ok(result);
        }
        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateBudget(int id, UpdateBudgetVM updateBudgetVM)
        {
            if (id != updateBudgetVM.Id)
            {
                return BadRequest();
            }
            var result = await _budgetService.UpdateBudget(updateBudgetVM);
            return Ok(result);
        }
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteBudget(int id)
        {
            var result   = await _budgetService.DeleteBudget(new DeleteBudgetVM { Id = id });
            return Ok(result);
        }
    }
}