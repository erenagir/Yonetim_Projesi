using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Application.Models.Dtos.Goals;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Models.RequestModels.Goals;
using X.Yönetim.Application.Wrapper;

namespace X.Yönetim.Application.Services.Abstraction
{
    public interface IGoalService
    {
        #region select işlemleri
        Task<Result<List<GoalDto>>> GetAllGoals();
        Task<Result<GoalDto>> GetGoalById(GetGoalByIdVM getGoalByIdVM);
        #endregion

        #region  Insert, Update, Delete
        Task<Result<int>> CreateGoal(CreateGoalVM createGoalVM);
        Task<Result<int>> UpdateGoal(UpdateGoalVM updateGoalVM);
        Task<Result<int>> DeleteGoal(DeleteGoalVM deleteGoalVM);
        #endregion
    }
}
