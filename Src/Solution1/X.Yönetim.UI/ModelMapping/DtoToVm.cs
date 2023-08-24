using AutoMapper;
using X.Yönetim.UI.Models.Dtos.Budgets;
using X.Yönetim.UI.Models.RequestModels.Budgets;

namespace X.Yönetim.UI.ModelMapping
{
    public class DtoToVm : Profile
    {
        public DtoToVm()
        {
            CreateMap<BudgetDto, UpdateBudgetVM>();
        }
    }
}
