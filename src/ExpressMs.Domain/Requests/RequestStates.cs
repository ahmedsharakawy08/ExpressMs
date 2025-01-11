using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace ExpressMs.Requests
{
    public class RequestStates :AuditedEntity<Guid>
    {
        public Guid ReqId { get; set; }
        [ForeignKey("ReqId")]
        public virtual Request Requests { set; get; }
        public RequestsStatus Status { get; set; }
        public Guid Current { set; get; }
        public RequestStates()
        {
        }
        public RequestStates(Guid reqId, RequestsStatus status, Guid current)
        {
            ReqId=reqId;
            Status=status;
            Current =current;
        }
    }
}
