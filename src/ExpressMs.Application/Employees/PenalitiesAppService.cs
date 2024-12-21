using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ExpressMs.Employees
{
    public class PenalitiesAppService : ExpressMsAppService
    {
        private readonly IRepository<Penalities, Guid> _penalitiesRepo;
        public PenalitiesAppService(IRepository<Penalities, Guid> penalitiesRepo)
        {
            _penalitiesRepo = penalitiesRepo;
        }
        public async Task<Penalities> CreateAsync(PenalityDto input)
        {
            var data = ObjectMapper.Map<PenalityDto, Penalities>(input);
            var result = await _penalitiesRepo.InsertAsync(data);
            return result;
        }
 
        public async Task<List<PenalityDto>> GetListAsync()
        {
            var penalities = await _penalitiesRepo.GetListAsync(true);
            var data = ObjectMapper.Map<List<Penalities>, List<PenalityDto>>(penalities);
            return data;
        }
        public async Task<List<PenalityDto>> GetPenalitiesByEmpIdAsync(Guid userId)
        {
            var penalities = await _penalitiesRepo.GetListAsync(obj=>obj.UserId==userId);
            var data = ObjectMapper.Map<List<Penalities>, List<PenalityDto>>(penalities);
            return data;
        }
    }
}
