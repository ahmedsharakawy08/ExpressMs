using ExpressMs.Employees;
using ExpressMs.Vacations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace ExpressMs.Requests
{
    public class RequestManager : IRequestManager
    {
        public readonly IRepository<EmployeesData> _employeesRepo;
        public readonly IRepository<RequestCycle> _requestCycleRepo;
        private readonly IRepository<RequestStates> _requestState;
        private readonly IVacationRequestApproval _vacationRequestApproval;
        private readonly IHiringRequestApproval _hiringRequestApproval;
        private readonly IPenalityRequestApproval _penalityRequestApproaval;
        private readonly IVacationRecordManager _vacrecordManager;
        private readonly IOverTimeRequestApproval _overTimeRequestApproval;
        private readonly IRewardRequestApproval _rewardRequestApproval;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IResignRequestApproval _resignRequestApproval;
        private readonly IClearanceRequestApproval _clearanceRequestApproval;

        public RequestManager(IRepository<EmployeesData> employeesRepo,
            IRepository<RequestCycle> requestCycleRepo
            , IVacationRequestApproval vacationRequestApproval,
            IVacationRecordManager vacrecordManager, IHiringRequestApproval hiringRequestApproval,
            IPenalityRequestApproval penalityRequestApproaval,
            IUnitOfWorkManager unitOfWorkManager,
            IOverTimeRequestApproval overTimeRequestApproval,
            IRewardRequestApproval rewardRequestApproval,
            IResignRequestApproval resignRequestApproval,
             IClearanceRequestApproval clearanceRequestApproval,
             IRepository<RequestStates> requestState

           )
        {
            _employeesRepo = employeesRepo;
            _requestCycleRepo = requestCycleRepo;
            _vacationRequestApproval = vacationRequestApproval;
            _vacrecordManager = vacrecordManager;
            _hiringRequestApproval = hiringRequestApproval;
            _unitOfWorkManager = unitOfWorkManager;
            _penalityRequestApproaval = penalityRequestApproaval;
            _overTimeRequestApproval = overTimeRequestApproval;
            _rewardRequestApproval = rewardRequestApproval;
            _resignRequestApproval = resignRequestApproval;
            _clearanceRequestApproval = clearanceRequestApproval;
            _requestState = requestState;
        }
        public async Task<Request> CreateRequest(BaseRequestConfig baseRequestConfig, string config)
        {
            var request = new Request();
            var user = await _employeesRepo.FindAsync(obj => obj.Users.Id == baseRequestConfig.UserId, true);
            if (user == null)
            {
                throw new UserFriendlyException("User not found");
            }

            var deptId = user.Position.DepartmentId;
            var requestcycle = await _requestCycleRepo.FindAsync(obj => obj.DeptId == deptId
            && obj.RequestTypes == RequestsTypes.Vacation);

            if (requestcycle == null)
            {
                throw new UserFriendlyException("No cycle for this department");
            }
            if (baseRequestConfig is VacationRequestConfiguration vacation)
            {
                var available = await _vacrecordManager.CheckRecordAvailable
                (vacation.UserId, vacation.VacationType, vacation.NoOfDays);

                if (!available)
                {
                    throw new UserFriendlyException("You donot have enough record");
                }
            }
            //if (baseRequestConfig is HiringRequestConfiguration hiring)
            //{
            //    request = new Request(Guid.NewGuid(), RequestsTypes.Hiring, requestcycle.Cycle,
            //                            config, RequestsStatus.Pending, baseRequestConfig.UserId);
            //}

            request = new Request(Guid.NewGuid(), baseRequestConfig.RequestsTypes, requestcycle.Cycle,
                                 config, RequestsStatus.Pending, baseRequestConfig.UserId);
            return request;
        }


        public async Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status)
        {
            switch (request.RequestsTypes)
            {
                case RequestsTypes.Vacation:
                    request = await _vacationRequestApproval.ProcessRequest(config, request, status);
                    break;
                case RequestsTypes.Hiring:
                    request = await _hiringRequestApproval.ProcessRequest(config, request, status);
                    break;
                case RequestsTypes.Penality:
                    request = await _penalityRequestApproaval.ProcessRequest(config, request, status);
                    break;
                case RequestsTypes.Resign:
                    request = await _resignRequestApproval.ProcessRequest(config, request, status);
                    break;
                case RequestsTypes.Clearance:
                    request = await _clearanceRequestApproval.ProcessRequest(config, request, status);
                    break;
                case RequestsTypes.OverTime:
                    request = await _overTimeRequestApproval.ProcessRequest(config, request, status);
                    break;
                case RequestsTypes.Rewards:
                    request = await _rewardRequestApproval.ProcessRequest(config, request, status);
                    break;
            }
           await  GenerateState(request);
            return request;
        }
        public async Task GenerateState(Request request)
        {
            var state = request.RequestStates.Where(obj => obj.Status == RequestsStatus.Pending).First();
            var cycle = await _requestCycleRepo.GetAsync(obj => obj.RequestTypes == request.RequestsTypes);
            var cycleArray = cycle.Cycle.Split(";");
            var last = Guid.Parse(cycleArray[cycleArray.Length - 1]);
            if(last == state.UserId)
            {
                return;
            }
            var requeststate = new RequestStates();
            requeststate.Status = RequestsStatus.Pending;
            var index = cycleArray.FindIndex(obj => Guid.Parse(obj) == state.UserId);
            requeststate.UserId = Guid.Parse(cycleArray[index + 1]);
            await _requestState.InsertAsync(requeststate);
        }
    }
}
