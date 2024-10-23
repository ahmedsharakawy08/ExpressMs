using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ExpressMs.GenericEntities
{
    public  class Governorate:Entity<int>
    {
        public string GovernorateNameAr { set; get; }
        public string GovernorateNameEn { set; get; }

      public  Governorate(string governorateNameAr, string governorateNameEn)
        {
            GovernorateNameAr = governorateNameAr;
            GovernorateNameEn = governorateNameEn;
        }

    }
}
