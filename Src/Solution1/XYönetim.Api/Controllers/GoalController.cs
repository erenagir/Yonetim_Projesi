using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Application.Models.Dtos.Goals;
using X.Yönetim.Application.Models.RequestModels.Accounts;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Models.RequestModels.Goals;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Wrapper;

namespace XYönetim.Api.Controllers
{
    [ApiController]
    [Route("goal")]
    [Authorize]
    public class GoalController : ControllerBase
    {

        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }



        [HttpGet("get")]
        public async Task<ActionResult<Result<List<GoalDto>>>> GetAllGoals()
        {
            var result = await _goalService.GetAllGoals();
            return Ok(result);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<GoalDto>>> GetGoalById(int id)
        {
            var result = await _goalService.GetGoalById(new GetGoalByIdVM { Id=id});
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateGoal(CreateGoalVM createGoalVM)
        {
            var result = await _goalService.CreateGoal(createGoalVM);
            return Ok(result);
        }
        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateGoal(int id, UpdateGoalVM updateGoalVM)
        {
            if (id != updateGoalVM.Id)
            {
                return BadRequest();
            }
            var result = await _goalService.UpdateGoal(updateGoalVM);
            return Ok(result);
        }
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteGoal(int id)
        {
            var result   = await _goalService.DeleteGoal(new DeleteGoalVM { Id = id });
            return Ok(result);
        }
    }
}