using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ExpressMs.Recruitment
{
    public class InsuranceData:AuditedEntity<Guid>
    {
        public string Type { set;get; } 
        public string CompanyNumber { set; get; }
        public string InsuranceNumber { set; get; }
        public DateTime SubscribedAt { set; get; }
        public double BasicSalary { set; get; }
        public double SubscribtionSalary { set; get; }
        public double GrossSalary { set; get; }
        public string RelationToBussinessOwner { set; get; }
        public DateTime DeflictStartDate { set; get; }
        public double DeflictPercent { set; get; }
        [ForeignKey("RecruitmentApplication")]
        public Guid ApplicationId { set; get; }
        [JsonIgnore]
        public virtual RecruitmentApplication RecruitmentApplication { set; get; }
    }
}
