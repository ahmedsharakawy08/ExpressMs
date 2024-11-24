using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.RectuitmentCo
{
    public class ApplicationDepartmentEvaluationDto
    {
        public string Type { set; get; }
        public string Strength { set; get; }
        public string Weakness { set; get; }
        public string Overall { set; get; }
        public Guid InterviewedBy { set; get; }
        public Guid ApplicationId { set; get; }
        public string Decision { set; get; }

    }
}
