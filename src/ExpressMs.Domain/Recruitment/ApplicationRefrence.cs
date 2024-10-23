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
    public class ApplicationRefrence:FullAuditedAggregateRoot<Guid>
    {
        public string Name { set; get; }
        public string Position { set;get; }
        public string Company { set; get; }
        public string Telohone { set; get;}
        [ForeignKey("RecruitmentApplication")]
        public Guid ApplicationId { set; get; }
        [JsonIgnore]
        public virtual RecruitmentApplication RecruitmentApplication { set; get; }
    }
}
