using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.Requests
{
    public interface IRequestManager 
    {
        public Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status);
        public Task<Request> CreateRequest(BaseRequestConfig baseRequestConfig, string config);
    }
}
