using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities.Auditing;

namespace ExpressMs.Recruitment
{
    public class SalaryDetails:AuditedEntity<Guid>
    {
        public double BasicSalary { set; get; }

        public double HouseAllowance { set; get; }
        public double TransportationAllowance { set; get; }

        public double OtherAllowances { set; get; }
        public double TotalSalary { set; get; }
        [ForeignKey("RecruitmentApplication")]
        public Guid ApplicationId { set; get; }
        [JsonIgnore]
        public virtual RecruitmentApplication RecruitmentApplication { set; get; }
    }
}
