using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities.Auditing;

namespace ExpressMs.Recruitment
{
    public class ComputerLanguageSkills:FullAuditedAggregateRoot<Guid>
    {
        public string Type { set;get; }
        public string Skill { set;get; }    
        public string evaluation { set;get; }
        [ForeignKey("RecruitmentApplication")]
        public Guid ApplicationId { set; get; }
        [JsonIgnore]
        public virtual RecruitmentApplication RecruitmentApplication { set; get; }



    }
}
