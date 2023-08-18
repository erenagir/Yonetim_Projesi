using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.RequestModels.Accounts;
using X.Yönetim.Domain.Entities;

namespace X.Yönetim.Application.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            //account-User işlemleri
            CreateMap<RegisterVM, User>();
            CreateMap<RegisterVM, Account>();
            CreateMap<UpdateUserVM, User>();

        }
    }
}
