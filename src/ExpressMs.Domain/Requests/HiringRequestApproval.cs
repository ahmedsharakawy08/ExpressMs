using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ExpressMs.Requests
{
    public class HiringRequestApproval : IHiringRequestApproval, ITransientDependency
    {
       public  HiringRequestApproval()
        {

        }

        public Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
