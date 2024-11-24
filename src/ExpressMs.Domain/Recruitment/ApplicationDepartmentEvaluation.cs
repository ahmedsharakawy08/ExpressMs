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
    public class ApplicationDepartmentEvaluation :AuditedEntity<Guid>
    {
        public string Type { set; get; }
        public string Strength { set; get; }
        public string Weakness { set; get; }    
        public string Overall { set;get; }
        public string InterviewedBy { set; get; }
        [ForeignKey("RecruitmentApplication")]
        public Guid ApplicationId { set; get; }
        [JsonIgnore]
        public virtual RecruitmentApplication RecruitmentApplication { set; get; }
        public string Decision { set; get; }
    }
}
