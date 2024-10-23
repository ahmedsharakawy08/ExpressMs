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
    public class ApplicationWorkExperiece : FullAuditedAggregateRoot<Guid>
    {
        public string CompanyName { set; get; }
        public string Location { set; get; }
        public string LastPosition { set; get; }
        public int Subord { set; get; }
        public double LastNetSalary { set; get; }
        public string LeavingReason { set; get; }
        public DateTime StartedForm { set; get; }
        public DateTime EndedAt { set; get; }
        [ForeignKey("RecruitmentApplication")]
        public Guid ApplicationId { set; get; }
        [JsonIgnore]
        public virtual RecruitmentApplication RecruitmentApplication { set; get; }
    }
}