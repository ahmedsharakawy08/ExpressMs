using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace ExpressMs.PayrollEntities
{
    public  class PayrollPaySlip:FullAuditedAggregateRoot<Guid>
    {
        public string? MobileNumber { set; get; }
        public string? FullName { set;get; }
        public string? Code { set;get; }
        public string? HtmlContent { set; get; }


    }
}
