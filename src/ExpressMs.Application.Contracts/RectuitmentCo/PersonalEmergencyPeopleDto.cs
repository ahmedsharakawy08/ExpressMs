using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.RectuitmentCo
{
    public class PersonalEmergencyPeopleDto
    {
        public string FullName { set; get; }
        public string Relation { set; get; }
        public string Type { set; get; }
        public string Number { set; get; }
        public Guid ApplicationId { set; get; }

    }
}
