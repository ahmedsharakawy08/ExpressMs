using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ExpressMs.Requests
{
    internal class RewardRequestApproval : IRewardRequestApproval
    {
        private readonly IRepository<RequestCycle> _requestCycleRepo;
        public readonly IRepository<RequestStates> _requestState;
        private readonly IRepository<Request> _request;
        public RewardRequestApproval(IRepository<RequestCycle> requestCycleRepo,
            IRepository<RequestStates> requestState, IRepository<Request> request)
        {

            _requestCycleRepo = requestCycleRepo;
            _requestState = requestState;
            _request = request;
        }
        public async Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status)
        {
            var state = request.RequestStates.Where(obj => obj.Status == RequestsStatus.Pending)
                    .First();
            var conf = (RewardsRequestFormConfiguration)config;
            conf.NoOfDays = conf.NoOfDays;
            await _request.UpdateAsync(request);

            state.Status = status;
            request.RequestState = state;
            var cycle = await _requestCycleRepo.GetAsync(obj => obj.RequestTypes == request.RequestsTypes);
            var cycleArray = cycle.Cycle.Split(";");
            var current = Guid.Parse(cycleArray[cycleArray.Length - 1]);

            var requeststate = new RequestStates();
            requeststate.Status = RequestsStatus.Pending;
            var index = cycleArray.FindIndex(obj => Guid.Parse(obj) == state.UserId);
            requeststate.UserId = Guid.Parse(cycleArray[index + 1]);
            await _requestState.InsertAsync(requeststate);
            return request;
        }
    }
}
