using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ExpressMs.Requests
{
    public  class RequestCycle:AuditedEntity<Guid>
    {
        public string Cycle { set; get; }
        public RequestsTypes RequestTypes { set; get; }
        public Guid DeptId { set; get; }
    }
}
