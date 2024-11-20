using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.RectuitmentCo
{
    public class SalaryDetailsDto
    {
        public double BasicSalary { set; get; }

        public double HouseAllowance { set; get; }
        public double TransportationAllowance { set; get; }

        public double OtherAllowances { set; get; }
        public double TotalSalary { set; get; }
    }
}
