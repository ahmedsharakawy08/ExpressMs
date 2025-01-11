using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.Requests
{
    public enum RequestsTypes
    {
        Vacation=1,
        Hiring=2
    }
    public enum RequestsStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected=3
    }
    public enum VacationType
    {
        Annual = 1,
        Casual = 2
    }
    public enum HiringRequestJobType
    {
        Replacement = 1,
        NewPosition = 2,
        Budgeted=3,
        NotBudgeted=4,
        PartTime=5,
        FullTime=6
    }
}
