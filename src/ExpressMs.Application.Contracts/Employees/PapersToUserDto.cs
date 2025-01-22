using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.Employees
{
    public class PapersToUserDto
    {
        public string  UserId { get; set; }
        public string UserName { get; set; }
        public  string  EmployeesPapersTypesName { set; get; }
        public bool status { set; get; }
        public string Content { set; get; }
    }
    public class CreatePapersToUserDto
    {
        public Guid  UserId { get; set; }
        public Guid  EmployeesPapersTypeId { set; get; }
        public string Content { set; get; }
    }
}
