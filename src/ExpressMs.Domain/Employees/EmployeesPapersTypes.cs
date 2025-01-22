using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ExpressMs.Employees
{
    public class EmployeesPapersTypes :Entity<Guid>
    {
        public string PaperName { set; get; }
       public EmployeesPapersTypes(string paperName)
        {
            PaperName = paperName;
        }
    }
}
