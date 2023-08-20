using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Domain.Entities;

namespace X.Yönetim.Application.AutoMapper
{
    public class DomainToDtoModel : Profile
    {
        public DomainToDtoModel()
        {
           CreateMap<Budget, BudgetDto>();
        }
    }
}
