using ExpressMs.Vacation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ExpressMs.Requests
{
    public  class RequestCycleAppService :ExpressMsAppService
    {
        public IRepository<RequestCycle> _requestCycleRepo;
        public RequestCycleAppService(IRepository<RequestCycle> requestCycleRepo) {
            _requestCycleRepo = requestCycleRepo;
        }
        public async Task CreatAsync(CreateRequestCycleDto input)
        {
            var data = ObjectMapper.Map<CreateRequestCycleDto, RequestCycle>(input);
            await _requestCycleRepo.InsertAsync(data);
        }
    }
}
