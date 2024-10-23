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
    public class ApplicationAddressData : FullAuditedAggregateRoot<Guid>
    {
        public string AppartmentNumber { set; get; }
        public string Town{set;get;}
        public string Street { set; get; }
        public string City { set; get; }
        public string Government { set; get; }
        [ForeignKey("RecruitmentApplication")]
        public Guid ApplicationId { set; get; }
        [JsonIgnore]
        public virtual RecruitmentApplication RecruitmentApplication { set; get; }
    }
}
