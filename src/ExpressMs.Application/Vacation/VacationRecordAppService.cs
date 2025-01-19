using ExpressMs.Vacations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ExpressMs.Vacation
{
    public class VacationRecordAppService : ExpressMsAppService
    {
        private readonly IRepository<VacationRecords> _vacationRecords;
        public VacationRecordAppService(IRepository<VacationRecords> vacationRecords)
        {
            _vacationRecords = vacationRecords;
        }
        public async Task CreateAsync(CreateVacationRecordDto input)
        {
            var data = ObjectMapper.Map<CreateVacationRecordDto, VacationRecords>(input);
            var exists = await _vacationRecords.FirstOrDefaultAsync(obj => obj.UserId == input.UserId);
            if (exists == null)
            {
                await _vacationRecords.InsertAsync(data);
            }
        }
        public async Task CreateWithList(List<CreateVacationRecordDto> input)
        {
            var data = ObjectMapper.Map<List<CreateVacationRecordDto>, List<VacationRecords>>(input);
            var existData = await _vacationRecords
                .GetListAsync();
            await _vacationRecords.DeleteManyAsync(existData);
            await _vacationRecords.InsertManyAsync(data);
        }

        public async Task<List<VacationRecordDto>> GetListAsync()
        {
            var vacation = await _vacationRecords.GetListAsync(true);
            var data = ObjectMapper.Map<List<VacationRecords>, List<VacationRecordDto>>(vacation);
            return data;
        }
        public async Task<VacationRecordDto> GetByUserId(Guid userId)
        {
            var vacation = await _vacationRecords.GetAsync(obj => obj.UserId == userId,true);
            var data = ObjectMapper.Map<VacationRecords,VacationRecordDto>(vacation);
            return data;
        }
        public async Task UpdateAsync(UpdateVacationRecordDto input)
        {
              _vacationRecords.DisableTracking();
            var vacation = _vacationRecords.GetListAsync(obj => obj.UserId == input.UserId);
            var data = ObjectMapper.Map<UpdateVacationRecordDto, VacationRecords>(input);
            await _vacationRecords.UpdateAsync(data);
        }
        public async Task DeleteVacationRecord(Guid  id)
        {
         await _vacationRecords.DeleteAsync(obj=>obj.Id == id);
        }
    }
}
