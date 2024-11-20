using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.RectuitmentCo
{
    public class InsuranceDataDto
    {
        public string Type { set; get; }
        public string CompanyNumber { set; get; }
        public string InsuranceNumber { set; get; }
        public DateTime SubscribedAt { set; get; }
        public double BasicSalary { set; get; }
        public double SubscribtionSalary { set; get; }
        public double GrossSalary { set; get; }
        public string RelationToBussinessOwner { set; get; }
        public DateTime DeflictStartDate { set; get; }
        public DateTime DeflictEndDate { set; get; }
    }
}
