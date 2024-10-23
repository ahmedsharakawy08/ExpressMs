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
    public class ApplicationTraining:FullAuditedAggregateRoot<Guid>
    {
        public string CourseName { set; get; }
        public string CourseLocation { set; get; }
        public string CourseCertificate { set; get; }
        public DateTime CourseFrom { set; get; }
        public string CourseTo { set; get; }
        [ForeignKey("RecruitmentApplication")]
        public Guid ApplicationId { set; get; }
        [JsonIgnore]
        public virtual RecruitmentApplication RecruitmentApplication { set; get; }

    }
}
