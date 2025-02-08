using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ExpressMs.Recruitment
{
    public class Company:Entity<Guid>
    {
        public string Name { set; get; }
        public ICollection<Department> Departments { set; get; }
        public Company()
        {
            Departments = new HashSet<Department>();
        }
    }
}
