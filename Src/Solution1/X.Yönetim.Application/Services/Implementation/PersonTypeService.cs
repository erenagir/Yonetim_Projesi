using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.Dtos;
using X.Yönetim.Application.Models.RequestModels;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Wrapper;

namespace X.Yönetim.Application.Services.Implementation
{
    public class PersonTypeService : IPersonTypeService
    {
        public Task<Result<int>> CreateCategory(CreatePersonTypeVM createPersonTypeVM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> DeleteCategory(DeletePersonTypeVM deletePersonTypeVM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<PersonTypeDto>>> GetAllPersonType()
        {
            throw new NotImplementedException();
        }

        public Task<Result<PersonTypeDto>> GetCategoryById(GetPersonTypeByIdVM getPersonTypeByIdVM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> UpdateCategory(UpdatePersonTypeVM updateCategoryVM)
        {
            throw new NotImplementedException();
        }
    }
}
