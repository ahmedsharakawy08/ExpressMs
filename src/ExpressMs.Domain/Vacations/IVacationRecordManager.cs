using ExpressMs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.Vacations
{
    public interface IVacationRecordManager
    {
        public Task SubtractRecord(Guid userId, VacationType vactype, double noOfDays);
        public Task<bool> CheckRecordAvailable(Guid userId, VacationType vactype, double noOfDays);
    }

}
