using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Application.Models.Dtos.Expenses;
using X.Yönetim.Application.Models.RequestModels.Accounts;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Models.RequestModels.Expenses;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Wrapper;

namespace XYönetim.Api.Controllers
{
    [ApiController]
    [Route("expense")]
    [Authorize]
    public class ExpenseController : ControllerBase
    {

        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Result<List<ExpenseDto>>>> GetAllExpenses()
        {
            var result = await _expenseService.GetAllExpenses();
            return Ok(result);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<ExpenseDto>>> GetExpenseById(int id)
        {
            var result = await _expenseService.GetExpenseById(new GetExpenseByIdVM { Id=id});
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateExpense(CreateExpenseVM createExpenseVM)
        {
            var result = await _expenseService.CreateExpense(createExpenseVM);
            return Ok(result);
        }
        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateExpense(int id, UpdateExpenseVM updateExpenseVM)
        {
            if (id != updateExpenseVM.Id)
            {
                return BadRequest();
            }
            var result = await _expenseService.UpdateExpense(updateExpenseVM);
            return Ok(result);
        }
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteExpense(int id)
        {
            var result = await _expenseService.DeleteExpense(new DeleteExpenseVM { Id = id });
            return Ok(result);
        }
    }
}