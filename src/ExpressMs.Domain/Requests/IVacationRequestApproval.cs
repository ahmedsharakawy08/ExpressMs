using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.Requests
{
    public interface IRequestApproval
    {
        public  Task<Request> ProcessRequest(BaseRequestConfig config,Request request, RequestsStatus status);
    }
    public interface IVacationRequestApproval
    {
        public Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status);
    }
    public interface IHiringRequestApproval 
    {
        public Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status);
    }
    public interface IPenalityRequestApproval
    {
        public Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status);
    }
    public interface IResignRequestApproval
    {
        public Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status);
    }
    public interface IClearanceRequestApproval
    {
        public Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status);
    }
    public interface IOverTimeRequestApproval
    {
        public Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status);
    }
    public interface IRewardRequestApproval
    {
        public Task<Request> ProcessRequest(BaseRequestConfig config, Request request, RequestsStatus status);
    }
}
