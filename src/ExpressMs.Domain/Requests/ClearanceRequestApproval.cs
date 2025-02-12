using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Http;
using Volo.Abp.Domain.Repositories;

namespace ExpressMs.Requests
{
    public class ClearanceRequestApproval : IClearanceRequestApproval
    {
        private readonly IRepository<RequestCycle> _requestCycleRepo;
        public readonly IRepository<RequestStates> _requestState;
        private readonly IRepository<Request> _request;
        public ClearanceRequestApproval(IRepository<RequestCycle> requestCycleRepo,
            IRepository<RequestStates> requestState,
            IRepository<Request> request)
        {
            _requestCycleRepo = requestCycleRepo;
            _requestState = requestState;
            _request = request;
        }
        public async Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status)
        {
            var state = request.RequestStates.Where(obj => obj.Status == RequestsStatus.Pending) .First();
            var conf = (ClearanceRequestFormConfiguration)config;
            conf.RejectionReasone = config.RejectionReasone;
            state.Status = status;
            request.RequestState = state;
            request.RequestConfigurations = JsonConvert.SerializeObject(conf);
            return request;
        }
    }
}
