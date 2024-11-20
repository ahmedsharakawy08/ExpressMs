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
    public class ApplicationDepartmentEvaluationAppService: ExpressMsAppService
    {
        private readonly IRepository<ApplicationDepartmentEvaluation> _AppDeptEvaluation;
        public ApplicationDepartmentEvaluationAppService(IRepository<ApplicationDepartmentEvaluation> AppDeptEvaluation)
        {
            _AppDeptEvaluation = AppDeptEvaluation;
        }
        public async Task CreateAsync(List<ApplicationDepartmentEvaluationDto> input) {

            var data = ObjectMapper.Map<List<ApplicationDepartmentEvaluationDto>,List<ApplicationDepartmentEvaluation>>(input);
           await _AppDeptEvaluation.InsertManyAsync(data);
        }
        public async Task UpdateAsyc(List<ApplicationDepartmentEvaluationDto> input,Guid appId)
        {
            var evaluation = await _AppDeptEvaluation.GetListAsync(obj => obj.ApplicationId == appId);
            var data = ObjectMapper.Map<List<ApplicationDepartmentEvaluationDto>, List<ApplicationDepartmentEvaluation>>(input, evaluation);
            await _AppDeptEvaluation.UpdateManyAsync(data);
        }
        public async Task<List<ApplicationDepartmentEvaluationDto>> GetByAppId( Guid appId)
        {
            var evaluation = await _AppDeptEvaluation.GetListAsync(obj => obj.ApplicationId == appId);
            var data = ObjectMapper.Map< List<ApplicationDepartmentEvaluation>, List<ApplicationDepartmentEvaluationDto>>(evaluation);
            return data;
        }

    }
}
