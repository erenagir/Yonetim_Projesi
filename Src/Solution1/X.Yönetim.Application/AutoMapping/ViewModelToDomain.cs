﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.RequestModels.Accounts;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Models.RequestModels.Expenses;
using X.Yönetim.Application.Models.RequestModels.Goals;
using X.Yönetim.Application.Models.RequestModels.Incomes;
using X.Yönetim.Application.Models.RequestModels.UserImages;
using X.Yönetim.Domain.Entities;

namespace X.Yönetim.Application.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            //account-User işlemleri
            CreateMap<RegisterVM, User>();
            CreateMap<RegisterVM, Account>()
                .ForMember(x=>x.Role,y=>y.MapFrom(e=>Roles.Admin));

            CreateMap<UpdateUserVM, User>();
               

            CreateMap<CreateBudgetVM, Budget>();
            CreateMap<UpdateBudgetVM, Budget>();


            CreateMap<CreateExpenseVM, Expense>();
            CreateMap<UpdateExpenseVM, Expense>();
            
            CreateMap<CreateIncomeVM, Income>();
            CreateMap<UpdateIncomeVM,Income>();

            CreateMap<CreateUserImageVM, UserImage>();

            CreateMap<CreateGoalVM, Goal>();
            CreateMap<UpdateGoalVM, Goal>();
        }
    }
}
