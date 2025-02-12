using ExpressMs.Vacations;
using Newtonsoft.Json;
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
        private readonly IRepository<RequestCycle> _requestCycleRepo;
        public readonly IRepository<RequestStates> _requestState;
        public HiringRequestApproval(
            IRepository<RequestCycle> requestCycleRepo,
            IRepository<RequestStates> requestState)
        {
            _requestCycleRepo = requestCycleRepo;
            _requestState = requestState;
        }


        public async Task<Request> ProcessRequest(BaseRequestConfig config, Request request, 
                                                    RequestsStatus status)
        {
            var state = request.RequestStates.Where(obj => obj.Status == RequestsStatus.Pending).First();
            var conf = (HiringRequestConfiguration)config;
            state.Status = status;
            request.RequestState = state;
            config.RejectionReasone=config.RejectionReasone;
            request.RequestConfigurations=JsonConvert.SerializeObject(conf);            
            var requeststate = new RequestStates();
            requeststate.Status = RequestsStatus.Pending;
            return request;
        }
    }
}
