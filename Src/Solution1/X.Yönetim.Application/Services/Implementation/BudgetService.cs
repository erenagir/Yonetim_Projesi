using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Behaviors;
using X.Yönetim.Application.Exceptions;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Validators.Budgets;
using X.Yönetim.Application.Wrapper;
using X.Yönetim.Domain.Entities;
using X.Yönetim.Domain.Services.Abstraction;
using X.Yönetim.Domain.UWork;

namespace X.Yönetim.Application.Services.Implementation
{
    public class BudgetService : IBudgetService
    {
        private readonly IUWork _uWork;
        private readonly IMapper _mapper;
        private readonly ILoggedUserService _loggedUserService;

        public BudgetService(IMapper mapper, IUWork uWork, ILoggedUserService loggedUserService)
        {
            _mapper = mapper;
            _uWork = uWork;
            _loggedUserService = loggedUserService;
        }

        /// <summary>
        /// tüm budget leri getirir
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<BudgetDto>>> GetAllBudgets()
        {
            var result = new Result<List<BudgetDto>>();
            var budgetEntites = await _uWork.GetRepository<Budget>().GetByFilterAsync(x=>x.UserId==_loggedUserService.UserId);
            var BudgetDtos = budgetEntites.ProjectTo<BudgetDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = BudgetDtos;
            _uWork.Dispose();
            return result;

        }


        /// <summary>
        /// id si verilen budget i getirir
        /// </summary>
        /// <param name="GetBudgetByIdVM"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        [ValidationBehavior(typeof(GetBudgetByValidator))]
        public async Task<Result<BudgetDto>> GetBudgetById(GetBudgetByIdVM GetBudgetByIdVM)
        {
            var result = new Result<BudgetDto>();


            var budgetExists = await _uWork.GetRepository<Budget>().AnyAsync(x => x.Id == GetBudgetByIdVM.Id);
            if (!budgetExists)
            {
                throw new NotFoundException($"{GetBudgetByIdVM.Id} numaralı bütçe bulunamadı.");
            }

            var budgetEntity = await _uWork.GetRepository<Budget>().GetSingleByFilterAsync(X=>(X.UserId==_loggedUserService.UserId) && (X.Id== GetBudgetByIdVM.Id));

            var budgetDto = _mapper.Map<Budget, BudgetDto>(budgetEntity);

            result.Data = budgetDto;
            _uWork.Dispose();
            return result;
        }

        /// <summary>
        /// yeni budget oluşturur
        /// </summary>
        /// <param name="createBudgetVM"></param>
        /// <returns></returns>
        [ValidationBehavior(typeof(CreateBudgetValidator))]
        public async Task<Result<int>> CreateBudget(CreateBudgetVM createBudgetVM)
        {
            var existsUser =await _uWork.GetRepository<User>().AnyAsync(x => x.Id == createBudgetVM.UserId);
            if (!existsUser )
            {
                throw new NotFoundException($"{createBudgetVM.UserId} numaralı kullanıcı bunamadı");
            }
            var result = new Result<int>();
            var budgetEntity = _mapper.Map<CreateBudgetVM, Budget>(createBudgetVM);
            _uWork.GetRepository<Budget>().Add(budgetEntity);
            await _uWork.CommitAsync();

            result.Data = budgetEntity.Id;
            _uWork.Dispose();
            return result;
        }


        /// <summary>
        /// budget siler
        /// </summary>
        /// <param name="deleteBudgetVM"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [ValidationBehavior(typeof(DeleteBudgetValidator))]
        public async Task<Result<int>> DeleteBudget(DeleteBudgetVM deleteBudgetVM)
        {
            var result = new Result<int>();

            var existsBudget = await _uWork.GetRepository<Budget>().GetByIdAsync(deleteBudgetVM);
            if (existsBudget is null)
            {
                throw new NotFoundException($"{deleteBudgetVM.Id} numaralı bütçe bulunamadı.");
            }

            _uWork.GetRepository<Budget>().Delete(deleteBudgetVM.Id);
            await _uWork.CommitAsync();
            result.Data = existsBudget.Id;
            _uWork.Dispose();
            return result;

        }


        /// <summary>
        /// budget güncelleme
        /// </summary>
        /// <param name="updateBudgetVM"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception> 
        [ValidationBehavior(typeof(UpdatebudgetValidator))]
        public async Task<Result<int>> UpdateBudget(UpdateBudgetVM updateBudgetVM)
        {
            var result = new Result<int>();
            var existsUser = await _uWork.GetRepository<User>().AnyAsync(x => x.Id == updateBudgetVM.UserId);
            if (!existsUser)
            {
                throw new NotFoundException($"{updateBudgetVM.UserId} numaralı kullanıcı bunamadı");
            }

            var budgetIdExists = await _uWork.GetRepository<Budget>().AnyAsync(x => x.Id == updateBudgetVM.Id);
            if (!budgetIdExists)
            {
                throw new NotFoundException($"{updateBudgetVM.Id} numaralı bütçe bulunamadı.");
            }

            var budgetNameExists = await _uWork.GetRepository<Budget>().AnyAsync(x => x.Id != updateBudgetVM.Id && x.Name == updateBudgetVM.Name.ToUpper().Trim());
            if (budgetNameExists)
            {
                throw new AlreadyExistsException($"{updateBudgetVM.Name} isminde bir bütçe önceden  eklenmiştir.");
            }

            var existsBudgetEntity = await _uWork.GetRepository<Budget>().GetByIdAsync(updateBudgetVM.Id);

            _mapper.Map(updateBudgetVM, existsBudgetEntity);

            _uWork.GetRepository<Budget>().Update(existsBudgetEntity);
            await _uWork.CommitAsync();
            result.Data = existsBudgetEntity.Id;
            _uWork.Dispose();
            return result;
        }
    }
}
