using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.Requests
{
    public class CreateRequestCycleDto
    {
        public string Cycle { set; get; }
        public RequestsTypes RequestTypes { set; get; }
        public Guid DeptId { set; get; }
    }
}
