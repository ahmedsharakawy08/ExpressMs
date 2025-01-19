using ExpressMs.Employees;
using ExpressMs.Vacations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Http;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;
using Task = System.Threading.Tasks.Task;

namespace ExpressMs.Requests
{
    public class RequestManager: IRequestManager,ITransientDependency
    {
        public readonly IRepository<EmployeesData> _employeesRepo;
        public readonly IRepository<RequestCycle> _requestCycleRepo;
        private readonly IVacationRequestApproval _vacationRequestApproval;
        private readonly IHiringRequestApproval _hiringRequestApproval;
        private readonly IVacationRecordManager _vacrecordManager;

        public RequestManager(IRepository<EmployeesData> employeesRepo,
            IRepository<RequestCycle> requestCycleRepo
            , IVacationRequestApproval vacationRequestApproval,
            IVacationRecordManager vacrecordManager, IHiringRequestApproval hiringRequestApproval
           )
        {
            _employeesRepo = employeesRepo;
            _requestCycleRepo = requestCycleRepo;
            _vacationRequestApproval = vacationRequestApproval;
            _vacrecordManager = vacrecordManager;
            _hiringRequestApproval =hiringRequestApproval;
        }
        public async Task<Request>  CreateRequest(BaseRequestConfig baseRequestConfig,string config)
        {
            var request=new Request();
            var user = await _employeesRepo.GetAsync(obj => obj.Users.Id == baseRequestConfig.UserId, true);
            var deptId = user.RecruitmentApplication.Positions.DepartmentId;

            var requestcycle = await _requestCycleRepo.GetAsync(obj => obj.DeptId == deptId
            && obj.RequestTypes == RequestsTypes.Vacation);
           
            if (baseRequestConfig is VacationRequestConfiguration vacation)
            {
                var available =await  _vacrecordManager.CheckRecordAvailable
                    (vacation.UserId, vacation.VacationType, vacation.NoOfDays);
              
                if(!available)
                {
                    throw new UserFriendlyException("you donot have enough record");
                }
                 request = new Request(Guid.NewGuid(),RequestsTypes.Vacation, requestcycle.Cycle,
                                         config, RequestsStatus.Pending);
            }
            if (baseRequestConfig is HiringRequestConfiguration hiring)
            {
                request = new Request(Guid.NewGuid(), RequestsTypes.Hiring, requestcycle.Cycle,
                                        config, RequestsStatus.Pending);
            }
            
            return request;
        }
        public async Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status)
        {
            switch (request.RequestsTypes)
            {
                case RequestsTypes.Vacation:
                    request= await  _vacationRequestApproval.ProcessRequest(config, request, status);
                    break;
                case RequestsTypes.Hiring:
                    request = await _hiringRequestApproval.ProcessRequest(config, request, status);
                    break;
            }

            return request;
        }
    }
}
