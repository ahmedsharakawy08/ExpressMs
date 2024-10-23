using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.RectuitmentCo
{
    public class ApplicationEducationDto
    {
        public string Education { set; get; }
        public string School { set; get; }
        public string Major { set; get; }
        public int GradYear { set; get; }
        public int RowNumber { set; get; }
    }
}
