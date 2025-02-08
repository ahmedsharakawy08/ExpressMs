using ExpressMs.Employees;
using ExpressMs.Vacations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Volo.Abp;

using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;
using Volo.Abp.Users;
using Task = System.Threading.Tasks.Task;

namespace ExpressMs.Requests
{
    public class RequestManager : IRequestManager
    {
        public readonly IRepository<EmployeesData> _employeesRepo;
        public readonly IRepository<RequestCycle> _requestCycleRepo;
        private readonly IVacationRequestApproval _vacationRequestApproval;
        private readonly IHiringRequestApproval _hiringRequestApproval;
        private readonly IPenalityRequestApproval _penalityRequestApproaval;
        private readonly IVacationRecordManager _vacrecordManager;
        private readonly IOverTimeRequestApproval _overTimeRequestApproval;
        private readonly IRewardRequestApproval _rewardRequestApproval;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public RequestManager(IRepository<EmployeesData> employeesRepo,
            IRepository<RequestCycle> requestCycleRepo
            , IVacationRequestApproval vacationRequestApproval,
            IVacationRecordManager vacrecordManager, IHiringRequestApproval hiringRequestApproval,
            IPenalityRequestApproval penalityRequestApproaval,
            IUnitOfWorkManager unitOfWorkManager,
            IOverTimeRequestApproval overTimeRequestApproval,
            IRewardRequestApproval rewardRequestApproval
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
                    request = await _penalityRequestApproaval.ProcessRequest(config, request, status);
                    break;
                case RequestsTypes.Clearance:
                    request = await _penalityRequestApproaval.ProcessRequest(config, request, status);
                    break;
                case RequestsTypes.OverTime:
                    request = await _penalityRequestApproaval.ProcessRequest(config, request, status);
                    break;
                case RequestsTypes.Rewards:
                    request = await _penalityRequestApproaval.ProcessRequest(config, request, status);
                    break;
            }
            return request;
        }
    }
}
