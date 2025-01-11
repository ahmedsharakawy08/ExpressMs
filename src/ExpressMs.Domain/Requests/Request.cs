using ExpressMs.Recruitment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Twilio.Http;
using Volo.Abp.Domain.Entities.Auditing;

namespace ExpressMs.Requests
{
    public class Request : AuditedEntity<Guid>
    {
        public RequestsTypes RequestsTypes { get; set; }
        public string ApprovalCycle { set; get; }
        public string RequestConfigurations {set;get;}    
        public RequestsStatus Status { set; get; }
        [NotMapped]
        public virtual RequestStates RequestState { get; set; }
        public ICollection<RequestStates> RequestStates { set; get; }
        public Request(Guid id,RequestsTypes requestsTypes, string approvalCycle, string requestConfigurations,
            RequestsStatus status)
        {
            RequestStates = new HashSet<RequestStates>();
            Id = id;
            RequestsTypes = requestsTypes;
            ApprovalCycle = approvalCycle;
            RequestConfigurations= requestConfigurations;
            Status = status;
            CreateRequestState(Id, approvalCycle);
        }
        public void CreateRequestState(Guid id,string approvalCycle)
        {
            var current = approvalCycle.Split(";");
            RequestState = new RequestStates(id, RequestsStatus.Pending, Guid.Parse(current[0]));
        }
        public Request() { }
        
    }
}
