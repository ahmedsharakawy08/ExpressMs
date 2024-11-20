using ExpressMs.Recruitment;
using ExpressMs.RectuitmentCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace ExpressMs.RecuruitmentApplication
{
    public class RecuruitmentApplicationAppService : ExpressMsAppService
    {
        private readonly IRepository<RecruitmentApplication> _recruitmentAppRepo;
        public RecuruitmentApplicationAppService(IRepository<RecruitmentApplication> recruitmentAppRepo)
        {
            _recruitmentAppRepo = recruitmentAppRepo;
        }
        public async Task<RecruitmentApplication> CreateAsync(CreateRecruitmentApplicationDto input)
        {
            var data = ObjectMapper.Map<CreateRecruitmentApplicationDto, RecruitmentApplication>(input);
            var result = await _recruitmentAppRepo.InsertAsync(data);
            return result;
        }
        public async Task<RecruitmentApplication> UpdateAysnc(Guid Id, UpdateRecruitmentApplicationDto input)
        {
            var data = await _recruitmentAppRepo.GetAsync(obj => obj.Id == Id);
            var map = ObjectMapper.Map<UpdateRecruitmentApplicationDto, RecruitmentApplication>(input, data);
            var result = await _recruitmentAppRepo.UpdateAsync(map);
            return result;
        }
        public async Task DeleteAysc(Guid Id)
        {
            var data = await _recruitmentAppRepo.GetListAsync(obj => obj.Id == Id, true);
            await _recruitmentAppRepo.DeleteAsync(data.First(), true);
        }
        public async Task<List<RecruitmentApplicationDto>> GetListAsync()
        {
            var data= await _recruitmentAppRepo.GetListAsync(true);
            var dto = ObjectMapper.Map<List<RecruitmentApplication>, List<RecruitmentApplicationDto>>(data);
            return dto;
        }
        public async Task<RecruitmentApplicationDto> GetByIdAsyc(Guid Id)
        {
            var data = await _recruitmentAppRepo.FindAsync(obj => obj.Id == Id, true);                
            return ObjectMapper.Map<RecruitmentApplication, RecruitmentApplicationDto>(data);
        }
    } 
}
