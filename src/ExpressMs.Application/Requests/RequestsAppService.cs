using ExpressMs.Employees;
using ExpressMs.Recruitment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace ExpressMs.Requests
{
    public class RequestsAppService:ExpressMsAppService
    {
        private readonly IRequestManager _requestManager;
        private readonly JsonSerializerSettings DataFlowSerializerSettings
            = new JsonSerializerSettings().AddDataFlowJsonConverter();
        public readonly IRepository<Request> _requestRepo;
        public readonly IRepository<RequestStates> _requestState;
        public RequestsAppService(IRequestManager requestManager,
            IRepository<Request> requestRepo,
            IRepository<RequestStates> requestState)
        {
            _requestManager = requestManager;
            _requestRepo = requestRepo;
            _requestState = requestState;
        }
        public async  void  CreateRequest(string requestConfig)
        {
            var config=JsonConvert.DeserializeObject<BaseRequestConfig>(requestConfig,DataFlowSerializerSettings);
            var request= await _requestManager.CreateRequest(config, requestConfig);
            await _requestRepo.InsertAsync(request);
            await _requestState.InsertAsync(request.RequestState);
        }
        public async Task Processrequest(Guid reqId, RequestsStatus status)
        {
            var request = await _requestRepo.GetAsync(obj=>obj.Id==reqId,true);
            var config = JsonConvert.DeserializeObject<BaseRequestConfig>(request.RequestConfigurations, DataFlowSerializerSettings);
            request = await  _requestManager.ProcessRequest(config, request, status);
            await _requestRepo.UpdateAsync(request);
            await _requestState.UpdateAsync(request.RequestState);
        }
    }
}
