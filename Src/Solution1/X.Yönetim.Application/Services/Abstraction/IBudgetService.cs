using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Wrapper;

namespace X.Yönetim.Application.Services.Abstraction
{
    public interface IBudgetService
    {
        #region select işlemleri
        Task<Result<List<BudgetDto>>> GetAllBudgets();
        Task<Result<BudgetDto>> GetBudgetById(GetBudgetByIdVM GetBudgetByIdVM);
        #endregion

        #region  Insert, Update, Delete
        Task<Result<int>> CreateBudget(CreateBudgetVM createBudgetVM);
        Task<Result<int>> UpdateBudget(UpdateBudgetVM updateBudgetVM);
        Task<Result<int>> DeleteBudget(DeleteBudgetVM deleteBudgetVM);
        #endregion
    }
}
