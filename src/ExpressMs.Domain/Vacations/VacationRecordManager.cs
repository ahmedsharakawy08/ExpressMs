using ExpressMs.Requests;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace ExpressMs.Vacations
{
    public class VacationRecordManager : IVacationRecordManager, ITransientDependency
    {
        private readonly IRepository<VacationRecords> _vacationRepo;
        public VacationRecordManager(IRepository<VacationRecords> vacationRepo)
        {
            _vacationRepo = vacationRepo;
        }
        public async Task SubtractRecord(Guid userId, VacationType vactype,double noOfDays)
        {
            var record=await _vacationRepo.GetAsync(obj=>obj.UserId==userId);

            if (vactype == VacationType.Annual && await CheckRecordAvailable( userId,  vactype,  noOfDays))
            {
                record.Annual-= noOfDays;
                await _vacationRepo.UpdateAsync(record);
                return;

            }
            if (vactype == VacationType.Casual && await CheckRecordAvailable(userId, vactype, noOfDays))
            {
                record.Casual -= noOfDays;
                await _vacationRepo.UpdateAsync(record);
                return;
            }
            throw new Exception("you donot have enough record");
        }
        public async Task<bool> CheckRecordAvailable(Guid userId, VacationType vactype, double noOfDays)
        {
            var record = await _vacationRepo.FindAsync(obj => obj.UserId == userId);
            if (vactype == VacationType.Annual && noOfDays < record.Annual)
            {
                return true;
            }
            if (vactype == VacationType.Casual && noOfDays < record.Casual)
            {
                return true;
            }
            return false;
        }
    }
}