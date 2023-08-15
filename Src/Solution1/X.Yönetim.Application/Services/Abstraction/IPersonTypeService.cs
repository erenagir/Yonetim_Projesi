using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Models.Dtos;
using X.Yönetim.Application.Models.RequestModels;
using X.Yönetim.Application.Wrapper;

namespace X.Yönetim.Application.Services.Abstraction
{
    public interface IPersonTypeService
    {
        #region Select
        Task<Result<List<PersonTypeDto>>> GetAllPersonType();
        Task<Result<PersonTypeDto>> GetCategoryById(GetPersonTypeByIdVM getPersonTypeByIdVM);

        #endregion

        #region Insert, Update, Delete
        Task<Result<int>> CreateCategory(CreatePersonTypeVM createPersonTypeVM);
        Task<Result<int>> UpdateCategory(UpdatePersonTypeVM updateCategoryVM);
        Task<Result<int>> DeleteCategory(DeletePersonTypeVM deletePersonTypeVM);
        #endregion
    }
}
