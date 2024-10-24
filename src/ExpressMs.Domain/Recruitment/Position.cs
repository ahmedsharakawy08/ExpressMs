using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace ExpressMs.Recruitment
{
    public class Position : Entity<Guid>
    {
        public string Name { set; get; }
        [ForeignKey("Department")]
        public Guid DepartmentId { set; get; }
        

    }
}
