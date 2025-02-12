using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ExpressMs.Requests
{
    public class OverTimeRequestApproval : IOverTimeRequestApproval
    {
        private readonly IRepository<RequestCycle> _requestCycleRepo;
        public readonly IRepository<RequestStates> _requestState;
        private readonly IRepository<Request> _request;
        public OverTimeRequestApproval(IRepository<RequestCycle> requestCycleRepo,
            IRepository<RequestStates> requestState, IRepository<Request> request)
        {

            _requestCycleRepo = requestCycleRepo;
            _requestState = requestState;
            _request = request;
        }
        public async Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status)
        {;
            var conf = (OverTimeRequestFormConfiguration)config;
            conf.Rate = conf.Rate;
            conf.TimeFrom = conf.TimeFrom;
            conf.TimeTo = conf.TimeTo;
            conf.RejectionReasone = conf.RejectionReasone;
            request.RequestConfigurations = JsonConvert.SerializeObject(conf);
            return request;
        }
    }
}
