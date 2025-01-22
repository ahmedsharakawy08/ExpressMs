using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace ExpressMs.Employees
{
    public class PapersToUsers:AuditedEntity<Guid>
    {
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser Users { set; get; }
        public Guid EmployeesPapersTypeId { get; set; }
        [ForeignKey("EmployeesPapersTypeId")]
        public virtual EmployeesPapersTypes EmployeesPapersTypes { set; get; }
        public bool Status { set; get; }
        public string Content { set; get; }

        public PapersToUsers(Guid userId, Guid employeesPapersTypeId,bool status,string content)
        {
            UserId = userId;
            EmployeesPapersTypeId = employeesPapersTypeId;
            Status = status;
            Content = content;
        }
        public PapersToUsers()
        {

        }
    }
}
