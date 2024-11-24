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
    public class PersonalEmergencyPeopleAppService : ExpressMsAppService
    {
        private readonly IRepository<PersonalEmergencyPeople> _InsuranceData;
        public PersonalEmergencyPeopleAppService(IRepository<PersonalEmergencyPeople> InsuranceData)
        {
            _InsuranceData = InsuranceData;
        }
        public async Task CreateAsync(PersonalEmergencyPeopleDto input)
        {
            var data = ObjectMapper.Map<PersonalEmergencyPeopleDto, PersonalEmergencyPeople>(input);
            await _InsuranceData.InsertAsync(data);
        }
        public async Task UpdateAsyc(PersonalEmergencyPeopleDto input, Guid appId)
        {
            var salary = await _InsuranceData.GetAsync(obj => obj.ApplicationId == appId);
            var data = ObjectMapper.Map<PersonalEmergencyPeopleDto, PersonalEmergencyPeople>(input, salary);
            await _InsuranceData.UpdateAsync(data);
        }
        public async Task<PersonalEmergencyPeopleDto> GetByAppId(Guid appId)
        {
            var salary = await _InsuranceData.GetAsync(obj => obj.ApplicationId == appId);
            var data = ObjectMapper.Map<PersonalEmergencyPeople, PersonalEmergencyPeopleDto>(salary);
            return data;
        }

    }
}