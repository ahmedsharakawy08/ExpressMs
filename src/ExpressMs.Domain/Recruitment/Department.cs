
using System;
using System.Collections;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace ExpressMs.Recruitment
{
    public  class Department:Entity<Guid>
    {
        public string Name { set; get; }
        public ICollection<Position> Poitions { set; get; }
        public Department()
        {
            Poitions=new HashSet<Position>();
        }

    }
}
