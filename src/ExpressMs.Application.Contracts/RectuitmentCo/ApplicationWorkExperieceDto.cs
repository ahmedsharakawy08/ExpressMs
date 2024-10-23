using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.RectuitmentCo
{
    public class ApplicationWorkExperieceDto
    {
        public string CompanyName { set; get; }
        public string Location { set; get; }
        public string LastPosition { set; get; }
        public int Subord { set; get; }
        public double LastNetSalary { set; get; }
        public string LeavingReason { set; get; }
        public DateTime StartedForm { set; get; }
        public DateTime EndedAt { set; get; }
    }
}
