using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace ExpressMs.Employees
{
    public class Penalities :AuditedEntity<Guid>
    {
        public Guid  UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser Users { set; get; }
        public string Details { set;get; }
        public DateTime Date { set; get; }
        public double NoOfDays { set; get; }

    }
}
