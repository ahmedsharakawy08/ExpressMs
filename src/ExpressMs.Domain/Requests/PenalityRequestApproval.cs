using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Http;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace ExpressMs.Requests
{
    public class PenalityRequestApproval : IPenalityRequestApproval
    {
        
        private readonly IRepository<RequestCycle> _requestCycleRepo;
        public readonly IRepository<RequestStates> _requestState;
        private readonly IRepository<Request> _request;
        public PenalityRequestApproval(IRepository<RequestCycle> requestCycleRepo,
            IRepository<RequestStates> requestState, IRepository<Request> request)
        {
            
            _requestCycleRepo = requestCycleRepo;
            _requestState = requestState;
            _request= request;
        }

        public async Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status)
        {
            var state = request.RequestStates.Where(obj => obj.Status == RequestsStatus.Pending)
                               .First();
            var conf = (PenalityRequestConfiguration)config;
            conf.NoOfDays = conf.NoOfDays;
            conf.AdminInvestigationRecomm= conf.AdminInvestigationRecomm;
            conf.HrRecomm = conf.HrRecomm;
            conf.AdminInvestigationReq = conf.AdminInvestigationReq;
            conf.ViolationRepeatition = conf.ViolationRepeatition;
            var configString=JsonConvert.SerializeObject(conf);
            request.RequestConfigurations = configString;
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
