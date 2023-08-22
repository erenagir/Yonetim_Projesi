using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.Yönetim.Application.Behaviors;
using X.Yönetim.Application.Exceptions;
using X.Yönetim.Application.Models.Dtos.Expenses;
using X.Yönetim.Application.Models.Dtos.Incomes;
using X.Yönetim.Application.Models.RequestModels.Expenses;
using X.Yönetim.Application.Models.RequestModels.Incomes;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Validators.Incomes;
using X.Yönetim.Application.Wrapper;
using X.Yönetim.Domain.Entities;
using X.Yönetim.Domain.Services.Abstraction;
using X.Yönetim.Domain.UWork;

namespace X.Yönetim.Application.Services.Implementation
{
    public class IncomeService : IIncomeService
    {
        private readonly IUWork _uWork;
        private readonly IMapper _mapper;
        private readonly ILoggedUserService _loggedUserService;

        public IncomeService(IMapper mapper, IUWork uWork, ILoggedUserService loggedUserService)
        {
            _mapper = mapper;
            _uWork = uWork;
            _loggedUserService = loggedUserService;
        }

        /// <summary>
        /// tüm gelirler
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<IncomeDto>>> GetAllIncomes()
        {
            var result = new Result<List<IncomeDto>>();
            var incomeEntites = await _uWork.GetRepository<Income>().GetAllAsync();
            var incomeDtos = incomeEntites.ProjectTo<IncomeDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = incomeDtos;
            _uWork.Dispose();
            return result;
        }

        /// <summary>
        /// verilen id ye ait gelir
        /// </summary>
        /// <param name="getIncomeByIdVM"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        [ValidationBehavior(typeof(GetIncomeByIdValidator))]
        public async Task<Result<IncomeDto>> GetIncomeById(GetIncomeByIdVM getIncomeByIdVM)
        {
            var result = new Result<IncomeDto>();

            var incomeEntity = await _uWork.GetRepository<Income>().GetSingleByFilterAsync(X => (X.UserId == _loggedUserService.UserId) && (X.Id == getIncomeByIdVM.Id));
            if (incomeEntity is null)
            {
                throw new NotFoundException($"{getIncomeByIdVM.Id} numaralı Gider bulunamadı.");
            }
            var incomeDto = _mapper.Map<Income, IncomeDto>(incomeEntity);

            result.Data = incomeDto;
            _uWork.Dispose();
            return result;
        }

        /// <summary>
        /// yeni gelir oluşturma
        /// </summary>
        /// <param name="createIncomeVM"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        [ValidationBehavior(typeof(CreateIncomeValidator))]
        public async Task<Result<int>> CreateIncome(CreateIncomeVM createIncomeVM)
        {
            var existsUser = await _uWork.GetRepository<User>().AnyAsync(x => x.Id == createIncomeVM.UserId);
            if (!existsUser)
            {
                throw new NotFoundException($"{createIncomeVM.UserId} numaralı kullanıcı bunamadı");
            }
            var existsBudget = await _uWork.GetRepository<Budget>().GetByIdAsync( createIncomeVM.BudgetId);
            if (existsBudget is null)
            {
                throw new NotFoundException($"{createIncomeVM.BudgetId} numaralı Bütçe bunamadı");
            }
            var result = new Result<int>();
            var ıncomeEntity = _mapper.Map<CreateIncomeVM, Income>(createIncomeVM);
            // geliri bütçeye ekle
            existsBudget.Amount += createIncomeVM.Amount;

            _uWork.GetRepository<Income>().Add(ıncomeEntity);
            _uWork.GetRepository<Budget>().Update(existsBudget);
            await _uWork.CommitAsync();

            result.Data = ıncomeEntity.Id;
            _uWork.Dispose();
            return result;
        }

        /// <summary>
        /// id si verilen geliri sil
        /// </summary>
        /// <param name="deleteIncomeVM"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        [ValidationBehavior(typeof(DeleteIncomeValidator))]
        public async Task<Result<int>> DeleteIncome(DeleteIncomeVM deleteIncomeVM)
        {
            var result = new Result<int>();

            var existsIncome = await _uWork.GetRepository<Income>().GetByIdAsync(deleteIncomeVM.Id);
            if (existsIncome is null)
            {
                throw new NotFoundException($"{deleteIncomeVM.Id} numaralı gelir bulunamadı.");
            }

            _uWork.GetRepository<Income>().Delete(existsIncome.Id);
            await _uWork.CommitAsync();
            result.Data = existsIncome.Id;
            _uWork.Dispose();
            return result;
        }

        /// <summary>
        /// id si verilen geliri güncelle
        /// </summary>
        /// <param name="updateIncomeVM"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        [ValidationBehavior(typeof(UpdateIncomeValidator))]
        public async Task<Result<int>> UpdateIncome(UpdateIncomeVM updateIncomeVM)
        {
            var result = new Result<int>();
            var existsUser = await _uWork.GetRepository<User>().AnyAsync(x => x.Id == updateIncomeVM.UserId);
            if (!existsUser)
            {
                throw new NotFoundException($"{updateIncomeVM.UserId} numaralı kullanıcı bunamadı");
            }

            //var budgetIdExists = await _uWork.GetRepository<Budget>().AnyAsync(x => x.Id == updateIncomeVM.BudgetId);
            //if (!budgetIdExists)
            //{
            //    throw new NotFoundException($"{updateIncomeVM.BudgetId} numaralı bütçe bulunamadı.");
            //}
            var incomeEntity = await _uWork.GetRepository<Income>().GetSingleByFilterAsync(x => x.Id == updateIncomeVM.Id);
            if (incomeEntity is null)
            {
                throw new NotFoundException($"{updateIncomeVM.Id} numaralı gelir bulunamadı.");
            }
            if (updateIncomeVM.BudgetId == incomeEntity.BudgetId)
            {

                throw new AlreadyExistsException("Bütçe bilgisi değitirilemez");
            }


            // bütce miktar bilgisi güncelleme
            var budgetExists = await _uWork.GetRepository<Budget>().GetByIdAsync(updateIncomeVM.BudgetId);
            budgetExists.Amount += updateIncomeVM.Amount;
            budgetExists.Amount -= incomeEntity.Amount;

            _mapper.Map(updateIncomeVM, incomeEntity);
            
            _uWork.GetRepository<Budget>().Update(budgetExists);
            _uWork.GetRepository<Income>().Update(incomeEntity);
            await _uWork.CommitAsync();
            result.Data = incomeEntity.Id;
            _uWork.Dispose();
            return result;
        }
    }
}
