using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Application.Models.Dtos.Expenses;
using X.Yönetim.Application.Models.Dtos.Incomes;
using X.Yönetim.Application.Models.RequestModels.Expenses;
using X.Yönetim.Application.Models.RequestModels.Incomes;
using X.Yönetim.Application.Wrapper;

namespace X.Yönetim.Application.Services.Abstraction
{
    public interface IIncomeService
    {
        #region Select
        Task<Result<List<IncomeDto>>> GetAllIncomes();
        Task<Result<IncomeDto>> GetIncomeById(GetIncomeByIdVM getIncomeByIdVM);
        #endregion

        #region  Insert, Update, Delete
        Task<Result<int>> CreateIncome(CreateIncomeVM createIncomeVM);
        Task<Result<int>> UpdateIncome(UpdateIncomeVM updateIncomeVM);
        Task<Result<int>> DeleteIncome(DeleteIncomeVM deleteIncomeVM);
        #endregion
    }
}
