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
    public class HiringRequestApproval : IHiringRequestApproval, ITransientDependency
    {
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<RequestCycle> _requestCycleRepo;
        public readonly IRepository<RequestStates> _requestState;
        public HiringRequestApproval(ICurrentUser currentUser,
            IRepository<RequestCycle> requestCycleRepo,
            IRepository<RequestStates> requestState)
        {
            _currentUser = currentUser;
            _requestCycleRepo = requestCycleRepo;
            _requestState = requestState;
        }


        public async Task<Request> ProcessRequest(BaseRequestConfig config, Request request, 
                                                    RequestsStatus status)
        {
            var state = request.RequestStates.Where(obj => obj.Status == RequestsStatus.Pending)
                                    .First();
            var conf = (HiringRequestConfiguration)config;
            if (_currentUser.Id != state.Current)
            {
                throw new UserFriendlyException("you donot have permission to approve this request");
            }
            state.Status = status;
            request.RequestState = state;
            var cycle = await _requestCycleRepo.GetAsync(obj => obj.RequestTypes == request.RequestsTypes);
            var cycleArray = cycle.Cycle.Split(";");
            var current = Guid.Parse(cycleArray[cycleArray.Length - 1]);

            var requeststate = new RequestStates();
            requeststate.Status = RequestsStatus.Pending;
            var index = cycleArray.FindIndex(obj => Guid.Parse(obj) == state.Current);
            requeststate.Current = Guid.Parse(cycleArray[index + 1]);
            await _requestState.InsertAsync(requeststate);
            return request;
        }
    }
}
