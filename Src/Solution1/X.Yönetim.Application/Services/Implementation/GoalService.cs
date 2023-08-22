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
using X.Yönetim.Application.Models.Dtos.Goals;
using X.Yönetim.Application.Models.RequestModels.Budgets;
using X.Yönetim.Application.Models.RequestModels.Goals;
using X.Yönetim.Application.Services.Abstraction;
using X.Yönetim.Application.Validators.Goals;
using X.Yönetim.Application.Wrapper;
using X.Yönetim.Domain.Entities;
using X.Yönetim.Domain.Services.Abstraction;
using X.Yönetim.Domain.UWork;

namespace X.Yönetim.Application.Services.Implementation
{
    public class GoalService : IGoalService
    {
        private readonly IUWork _uWork;
        private readonly IMapper _mapper;
        private readonly ILoggedUserService _loggedUserService;
        public GoalService(IMapper mapper, IUWork uWork, ILoggedUserService loggedUserService)
        {
            _mapper = mapper;
            _uWork = uWork;
            _loggedUserService = loggedUserService;
        }
        public async Task<Result<List<GoalDto>>> GetAllGoals()
        {
            var result = new Result<List<GoalDto>>();
            var goalEntites = await _uWork.GetRepository<Goal>().GetByFilterAsync(x => x.UserId == _loggedUserService.UserId);
            var goalDtos = goalEntites.ProjectTo<GoalDto>(_mapper.ConfigurationProvider).ToList();
            result.Data = goalDtos;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof( GetGoalByIdValidator))]
        public async Task<Result<GoalDto>> GetGoalById(GetGoalByIdVM getGoalByIdVM)
        {
            var result = new Result<GoalDto>();


           

            var goalEntity = await _uWork.GetRepository<Goal>().GetSingleByFilterAsync(X => (X.UserId == _loggedUserService.UserId) && (X.Id == getGoalByIdVM.Id));
            if (goalEntity is null)
            {
                throw new NotFoundException($"{getGoalByIdVM.Id} numaralı hedef bulunamadı.");
            }

            var goalDto = _mapper.Map<Goal, GoalDto>(goalEntity);

            result.Data = goalDto;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(CreateGoalValidator))]
        public async Task<Result<int>> CreateGoal(CreateGoalVM createGoalVM)
        {
            var existsUser = await _uWork.GetRepository<User>().AnyAsync(x => x.Id == createGoalVM.UserId);
            if (!existsUser)
            {
                throw new NotFoundException($"{createGoalVM.UserId} numaralı kullanıcı bunamadı");
            }
            var result = new Result<int>();
            var goalEntity = _mapper.Map<CreateGoalVM, Goal>(createGoalVM);
            _uWork.GetRepository<Goal>().Add(goalEntity);
            await _uWork.CommitAsync();

            result.Data = goalEntity.Id;
            _uWork.Dispose();
            return result;

        }

        [ValidationBehavior(typeof(DeleteGoalValidator))]
        public async Task<Result<int>> DeleteGoal(DeleteGoalVM deleteGoalVM)
        {
            var result = new Result<int>();

            var existsGoal = await _uWork.GetRepository<Budget>().GetByIdAsync(deleteGoalVM);
            if (existsGoal is null)
            {
                throw new NotFoundException($"{deleteGoalVM.Id} numaralı hedef bulunamadı.");
            }

            _uWork.GetRepository<Goal>().Delete(existsGoal);
            await _uWork.CommitAsync();
            result.Data = existsGoal.Id;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdateGoalValidator))]
        public async Task<Result<int>> UpdateGoal(UpdateGoalVM updateGoalVM)
        {
            var result = new Result<int>();
            var existsUser = await _uWork.GetRepository<User>().AnyAsync(x => x.Id == updateGoalVM.UserId);
            if (!existsUser)
            {
                throw new NotFoundException($"{updateGoalVM.UserId} numaralı kullanıcı bulunamadı");
            }

            var budgetIdExists = await _uWork.GetRepository<Goal>().AnyAsync(x => x.Id == updateGoalVM.Id);
            if (!budgetIdExists)
            {
                throw new NotFoundException($"{updateGoalVM.Id} numaralı hedef bulunamadı.");
            }

           

            var existsGoalEntity = await _uWork.GetRepository<Goal>().GetByIdAsync(updateGoalVM.Id);

            _mapper.Map(updateGoalVM, existsGoalEntity);

            _uWork.GetRepository<Goal>().Update(existsGoalEntity);
            await _uWork.CommitAsync();
            result.Data = existsGoalEntity.Id;
            _uWork.Dispose();
            return result;
        }
    }
}
