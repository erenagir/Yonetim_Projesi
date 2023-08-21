using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Application.Models.Dtos.Expenses;
using X.Yönetim.Application.Models.Dtos.Incomes;
using X.Yönetim.Application.Models.RequestModels.Accounts;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Models.RequestModels.Expenses;
using X.Yönetim.Application.Models.RequestModels.Incomes;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Wrapper;

namespace XYönetim.Api.Controllers
{
    [ApiController]
    [Route("income")]
    //[Authorize]
    public class IncomeController : ControllerBase
    {

        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<IncomeDto>>>> GetAllIncomes()
        {
            var result = await _incomeService.GetAllIncomes();
            return Ok(result);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<ExpenseDto>>> GetIncomeById(int id)
        {
            var result = await _incomeService.GetIncomeById(new GetIncomeByIdVM { Id=id});
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateIncome(CreateIncomeVM createIncomeVM)
        {
            var result = await _incomeService.CreateIncome(createIncomeVM);
            return Ok(result);
        }
        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateIncome(int id, UpdateIncomeVM updateIncomeVM)
        {
            if (id != updateIncomeVM.Id)
            {
                return BadRequest();
            }
            var result = await _incomeService.UpdateIncome(updateIncomeVM);
            return Ok(result);
        }
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteIncome(int id)
        {
            var result = await _incomeService.DeleteIncome(new DeleteIncomeVM { Id = id });
            return Ok(result);
        }
    }
}