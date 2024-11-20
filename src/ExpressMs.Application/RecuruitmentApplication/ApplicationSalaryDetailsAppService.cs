using ExpressMs.Recruitment;
using ExpressMs.RectuitmentCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace ExpressMs.RecuruitmentApplication
{
    public class ApplicationSalaryDetailsAppService : ExpressMsAppService
    {
        private readonly IRepository<SalaryDetails> _AppSalaryDetails;
        public ApplicationSalaryDetailsAppService(IRepository<SalaryDetails> AppSalaryDetails)
        {
            _AppSalaryDetails = AppSalaryDetails;
        }
        public async Task CreateAsync(SalaryDetailsDto input)
        {
            var data = ObjectMapper.Map<SalaryDetailsDto, SalaryDetails>(input);
            await _AppSalaryDetails.InsertAsync(data);
        }
        public async Task UpdateAsyc(SalaryDetailsDto input, Guid appId)
        {
            var salary = await _AppSalaryDetails.GetAsync(obj => obj.ApplicationId == appId);
            var data = ObjectMapper.Map<SalaryDetailsDto, SalaryDetails>(input, salary);
            await _AppSalaryDetails.InsertAsync(data);
        }
        public async Task<SalaryDetailsDto> GetByAppId(Guid appId)
        {
            var salary = await _AppSalaryDetails.GetAsync(obj => obj.ApplicationId == appId);
            var data = ObjectMapper.Map<SalaryDetails, SalaryDetailsDto>(salary);
            return data;
        }

    }
}