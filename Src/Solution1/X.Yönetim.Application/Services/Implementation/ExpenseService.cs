using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Behaviors;
using X.Yönetim.Application.Exceptions;
using X.Yönetim.Application.Models.Dtos.Budgets;
using X.Yönetim.Application.Models.Dtos.Expenses;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Models.RequestModels.Expenses;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Validators.Budgets;
using X.Yönetim.Application.Validators.Expenses;
using X.Yönetim.Application.Wrapper;
using X.Yönetim.Domain.Entities;
using X.Yönetim.Domain.Services.Abstraction;
using X.Yönetim.Domain.UWork;

namespace X.Yönetim.Application.Services.Implementation
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUWork _uWork;
        private readonly IMapper _mapper;
        private readonly ILoggedUserService _loggedUserService;

        public ExpenseService(IMapper mapper, IUWork uWork,  ILoggedUserService loggedUserService)
        {
            _mapper = mapper;
            _uWork = uWork;
            _loggedUserService = loggedUserService;
        }

        /// <summary>
        /// tüm expense leri getirir
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<ExpenseDto>>> GetAllExpenses()
        {
            var result = new Result<List<ExpenseDto>>();
            var expenseEntites = await _uWork.GetRepository<Expense>().GetByFilterAsync(x => x.UserId == _loggedUserService.UserId); 
            var expenseDtos = expenseEntites.ProjectTo<ExpenseDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = expenseDtos;
            _uWork.Dispose();
            return result;
        }
        /// <summary>
        /// verilen id ye göre Expense getirir
        /// </summary>
        /// <param name="getExpenseByIdVM"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        [ValidationBehavior(typeof(GetExpenseByValidator))]
        public async Task<Result<ExpenseDto>> GetExpenseById(GetExpenseByIdVM getExpenseByIdVM)
        {
            var result = new Result<ExpenseDto>();

            var expenseEntity = await _uWork.GetRepository<Expense>().GetSingleByFilterAsync(X => (X.UserId == _loggedUserService.UserId) && (X.Id == getExpenseByIdVM.Id));
            if (expenseEntity is null)
            {
                throw new NotFoundException($"{getExpenseByIdVM.Id} numaralı Gider bulunamadı.");
            }
            var ExpenseDto = _mapper.Map<Expense, ExpenseDto>(expenseEntity);

            result.Data = ExpenseDto;
            _uWork.Dispose();
            return result;
        }

        /// <summary>
        /// yeni expense oluşturur
        /// </summary>
        /// <param name="createExpenseVM"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        [ValidationBehavior(typeof(CreateExpenseValidator))]
        public async Task<Result<int>> CreateExpense(CreateExpenseVM createExpenseVM)
        {
            var existsUser = await _uWork.GetRepository<User>().AnyAsync(x => x.Id == createExpenseVM.UserId);
            if (!existsUser)
            {
                throw new NotFoundException($"{createExpenseVM.UserId} numaralı kullanıcı bunamadı");
            }
            var existsBudget = await _uWork.GetRepository<Budget>().GetByIdAsync(createExpenseVM.BudgetId);
            if (existsBudget is null)
            {
                throw new NotFoundException($"{createExpenseVM.BudgetId} numaralı Bütçe bunamadı");
            }
            //Gideri Bütçeden düş
            existsBudget.Amount -= createExpenseVM.Amount;
            
            var result = new Result<int>();
            var expenseEntity = _mapper.Map<CreateExpenseVM, Expense>(createExpenseVM);
            _uWork.GetRepository<Expense>().Add(expenseEntity);
            _uWork.GetRepository<Budget>().Update(existsBudget);
            
            await _uWork.CommitAsync();

            result.Data = expenseEntity.Id;
            _uWork.Dispose();
            return result;
        }

        /// <summary>
        /// expense siler
        /// </summary>
        /// <param name="deleteExpenseVM"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        [ValidationBehavior(typeof(DeleteExpenseValidator))]
        public async Task<Result<int>> DeleteExpense(DeleteExpenseVM deleteExpenseVM)
        {
            var result = new Result<int>();

            var existsExpense = await _uWork.GetRepository<Expense>().GetByIdAsync(deleteExpenseVM.Id);
            if (existsExpense is null)
            {
                throw new NotFoundException($"{deleteExpenseVM.Id} numaralı gider bulunamadı.");
            }
            var existsBudget = await _uWork.GetRepository<Budget>().GetByIdAsync(existsExpense.BudgetId);
            // gideri bütçeye tekrar ekle
            existsBudget.Amount += existsExpense.Amount;
            _uWork.GetRepository<Expense>().Delete(existsExpense.Id);
            _uWork.GetRepository<Budget>().Update(existsBudget);
            await _uWork.CommitAsync();
            result.Data = existsExpense.Id;
            _uWork.Dispose();
            return result;
        }

        /// <summary>
        /// expense günceller
        /// </summary>
        /// <param name="updateExpenseVM"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        [ValidationBehavior(typeof(UpdateExpenseValidator))]
        public async Task<Result<int>> UpdateExpense(UpdateExpenseVM updateExpenseVM)
        {
            var result = new Result<int>();
            var existsUser = await _uWork.GetRepository<User>().AnyAsync(x => x.Id == updateExpenseVM.UserId);
            if (!existsUser)
            {
                throw new NotFoundException($"{updateExpenseVM.UserId} numaralı kullanıcı bunamadı");
            }

            //var budgetIdExists = await _uWork.GetRepository<Budget>().AnyAsync(x => x.Id == updateExpenseVM.BudgetId);
            //if (!budgetIdExists)
            //{
            //    throw new NotFoundException($"{updateExpenseVM.BudgetId} numaralı bütçe bulunamadı.");
            //}
            var expenseExistsEntity = await _uWork.GetRepository<Expense>().GetSingleByFilterAsync(x => x.Id == updateExpenseVM.Id);
            if (expenseExistsEntity is null)
            {
                throw new NotFoundException($"{updateExpenseVM.Id} numaralı gider bulunamadı.");
            }
            if (updateExpenseVM.BudgetId==expenseExistsEntity.BudgetId)
            {

                throw new AlreadyExistsException("Bütçe bilgisi değitirilemez");
            }

            // bütce miktar bilgisi güncelleme
           var budgetExists = await _uWork.GetRepository<Budget>().GetByIdAsync(updateExpenseVM.BudgetId);
            budgetExists.Amount += expenseExistsEntity.Amount;
            budgetExists.Amount -= updateExpenseVM.Amount;

            _mapper.Map(updateExpenseVM, expenseExistsEntity);
            
            
            _uWork.GetRepository<Budget>().Update(budgetExists);
            _uWork.GetRepository<Expense>().Update(expenseExistsEntity);
            await _uWork.CommitAsync();
            result.Data = expenseExistsEntity.Id;
            _uWork.Dispose();
            return result;
        }
    }
}
