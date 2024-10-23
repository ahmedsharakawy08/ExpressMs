using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities.Auditing;

namespace ExpressMs.Recruitment
{
    public  class RecruitmentApplicationEducation : FullAuditedAggregateRoot<Guid>
    {
        public string Education { set; get; }
        public string School { set; get; }
        public string Major { set; get; }
        public int GradYear { set; get; }
        public int RowNumber { set; get; }
        [ForeignKey("RecruitmentApplication")]

        public Guid ApplicationId { set; get; }
        [JsonIgnore]
        public virtual RecruitmentApplication RecruitmentApplication { set; get; }


    }
}
