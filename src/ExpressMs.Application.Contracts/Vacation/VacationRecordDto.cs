using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.Vacation
{
    public class CreateVacationRecordDto
    {
        public Guid UserId { get; set; }
        public double Annual { get; set; }
        public double Casual { get; set; }
    }
    public class VacationRecordDto
    {
        public Guid Id { set; get; }
        public Guid UserId { get; set; }
        public string Name { set; get; }
        public double Annual { get; set; }
        public double Casual { get; set; }
    }
    public class UpdateVacationRecordDto
    { 
        public Guid UserId { get; set; }
        public double Annual { get; set; }
        public double Casual { get; set; }
    }
}
