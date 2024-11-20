using ExpressMs.Recruitment;
using ExpressMs.RectuitmentCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ExpressMs.RecuruitmentApplication
{
    public class InsuranceDataAppService : ExpressMsAppService
    {
        private readonly IRepository<InsuranceData> _InsuranceData;
        public InsuranceDataAppService(IRepository<InsuranceData> InsuranceData)
        {
            _InsuranceData = InsuranceData;
        }
        public async Task CreateAsync(InsuranceDataDto input)
        {
            var data = ObjectMapper.Map<InsuranceDataDto, InsuranceData>(input);
            await _InsuranceData.InsertAsync(data);
        }
        public async Task UpdateAsyc(InsuranceDataDto input, Guid appId)
        {
            var salary = await _InsuranceData.GetAsync(obj => obj.ApplicationId == appId);
            var data = ObjectMapper.Map<InsuranceDataDto, InsuranceData>(input, salary);
            await _InsuranceData.UpdateAsync(data);
        }
        public async Task<InsuranceDataDto> GetByAppId(Guid appId)
        {
            var salary = await _InsuranceData.GetAsync(obj => obj.ApplicationId == appId);
            var data = ObjectMapper.Map<InsuranceData, InsuranceDataDto>(salary);
            return data;
        }

    }
}