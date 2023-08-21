using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Application.Models.Dtos.Expenses;

using X.Yönetim.Application.Models.RequestModels.Expenses;
using X.Yönetim.Application.Wrapper;

namespace X.Yönetim.Application.Services.Abstraction
{
    public interface IExpenseService
    {
        #region Select
        Task<Result<List<ExpenseDto>>> GetAllExpenses();
        Task<Result<ExpenseDto>> GetExpenseById(GetExpenseByIdVM getExpenseByIdVM);
        #endregion

        #region  Insert, Update, Delete
        Task<Result<int>> CreateExpense(CreateExpenseVM createExpenseVM);
        Task<Result<int>> UpdateExpense(UpdateExpenseVM updateExpenseVM);
        Task<Result<int>> DeleteExpense(DeleteExpenseVM deleteExpenseVM);
        #endregion
    }
}
