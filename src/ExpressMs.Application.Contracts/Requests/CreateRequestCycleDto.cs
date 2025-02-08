using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.Requests
{
    public class CreateRequestCycleDto
    {
        public string Cycle { set; get; }
        public RequestsTypes RequestTypes { set; get; }
        public Guid DeptId { set; get; }
    }
    public class GetAllRequestsDto
    {
        public RequestsTypes RequestsTypes { get; set; }
        public string ApprovalCycle { set; get; }
        public string RequestConfigurations { set; get; }
        public RequestsStatus Status { set; get; }
        public Guid RequesterId { get; set; }
        public Guid RequesterName { get; set; }
        public string CurrentApproval { set; get; }
    }
    public class GetRequestToApproveDto
    {
        public Guid Id { set; get; }
        public RequestsTypes RequestsTypes { get; set; }
        public string RequestConfigurations { set; get; }
        public RequestsStatus Status { set; get; }
        public Guid RequesterId { get; set; }
        public string RequesterName { get; set; }
        public DateTime CreationTime { set; get; }
    }
}
