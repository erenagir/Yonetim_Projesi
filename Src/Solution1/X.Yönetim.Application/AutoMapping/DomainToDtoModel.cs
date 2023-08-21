using AutoMapper;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Application.Models.Dtos.Expenses;
using X.Yönetim.Application.Models.Dtos.Goals;
using X.Yönetim.Application.Models.Dtos.Incomes;
using X.Yönetim.Application.Models.Dtos.UserImages;
using X.Yönetim.Domain.Entities;

namespace X.Yönetim.Application.AutoMapper
{
    public class DomainToDtoModel : Profile
    {
        public DomainToDtoModel()
        {
           CreateMap<Budget, BudgetDto>();
           CreateMap<Expense, ExpenseDto>();
            CreateMap<Income, IncomeDto>();
            CreateMap<UserImage,UserImageDto>();
            CreateMap<Goal, GoalDto>();
        }
    }
}
