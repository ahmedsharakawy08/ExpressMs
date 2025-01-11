using ExpressMs.Vacations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace ExpressMs.Requests
{
    public class VacationRequestApproval : IVacationRequestApproval,ITransientDependency
    {
        public readonly IRepository<RequestStates> _requestState;
        private readonly IRepository<Request> _requestRepo;
        private readonly IRepository<RequestCycle> _requestCycleRepo;
        private readonly ICurrentUser _currentUser;
        private readonly IVacationRecordManager _vacationRecord;
        private readonly IVacationRecordManager _vacrecordManager;
        public VacationRequestApproval(IRepository<RequestStates> requestState,
             IRepository<Request> requestRepo,
             IRepository<RequestCycle> requestCycleRepo, ICurrentUser currentUser,
             IVacationRecordManager vacationRecord
            , IVacationRecordManager vacrecordManager)
        {
            _requestState = requestState;
            _requestRepo = requestRepo;
            _requestCycleRepo = requestCycleRepo;
            _currentUser = currentUser;
            _vacationRecord = vacationRecord;
            _vacrecordManager = vacrecordManager;
        }
        public  async Task<Request> ProcessRequest(BaseRequestConfig config,Request request, RequestsStatus status)
        {
            var state = request.RequestStates.Where(obj =>obj.Status == RequestsStatus.Pending)
                                            .First();
            var conf = (VacationRequestConfiguration)config;
            if (_currentUser.Id != state.Current)
            {
                throw new UserFriendlyException("you donot have permission to approve this request");
            }

            var available = await _vacrecordManager.CheckRecordAvailable
                   (conf.UserId, conf.VacationType, conf.NoOfDays);

            if (!available)
            {
                throw new UserFriendlyException("this employee doesnot have enough record");
            }
            state.Status = status;
            request.RequestState= state;
            var cycle = await _requestCycleRepo.GetAsync(obj => obj.RequestTypes == request.RequestsTypes);
            var cycleArray = cycle.Cycle.Split(";");
            var current = Guid.Parse(cycleArray[cycleArray.Length - 1]);
            if (current == state.Current)
            {
               await  _vacationRecord.SubtractRecord(conf.UserId, conf.VacationType, conf.NoOfDays);
                request.Status = status;
                return request;
            }

            var requeststate = new RequestStates();
            requeststate.Status = RequestsStatus.Pending;
            var index = cycleArray.FindIndex(obj => Guid.Parse(obj) == state.Current);
            requeststate.Current = Guid.Parse(cycleArray[index + 1]);
            await _requestState.InsertAsync(requeststate);
            return request;
        }
    }
}
