using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.RectuitmentCo
{
    public  class ApplicationPersonalEvaluationDto
    {
        public string Type { set; get; }
        public string Value { set; get; }
        public string Comments { set; get; }
    }
}
