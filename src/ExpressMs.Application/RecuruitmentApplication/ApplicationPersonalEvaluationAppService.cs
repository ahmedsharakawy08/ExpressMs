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
    public class ApplicationPersonalEvaluationAppService : ExpressMsAppService
    {
        private readonly IRepository<ApplicationPersonalEvaluation> _AppPersonalEvaluation;
        public ApplicationPersonalEvaluationAppService(IRepository<ApplicationPersonalEvaluation> AppPersonalEvaluation)
        {
            _AppPersonalEvaluation = AppPersonalEvaluation;
        }
        public async Task CreateAsync(List<ApplicationPersonalEvaluationDto> input)
        {

            var data = ObjectMapper.Map<List<ApplicationPersonalEvaluationDto>, List<ApplicationPersonalEvaluation>>(input);
            await _AppPersonalEvaluation.InsertManyAsync(data);
        }
        public async Task UpdateAsyc(List<ApplicationPersonalEvaluationDto> input, Guid appId)
        {
            var evaluation = await _AppPersonalEvaluation.GetListAsync(obj => obj.ApplicationId == appId);
            var data = ObjectMapper.Map<List<ApplicationPersonalEvaluationDto>, List<ApplicationPersonalEvaluation>>(input, evaluation);
            await _AppPersonalEvaluation.UpdateManyAsync(data);
        }
        public async Task<List<ApplicationPersonalEvaluationDto>> GetByAppId(Guid appId)
        {
            var evaluation = await _AppPersonalEvaluation.GetListAsync(obj => obj.ApplicationId == appId);
            var data = ObjectMapper.Map<List<ApplicationPersonalEvaluation>, List<ApplicationPersonalEvaluationDto>>(evaluation);
            return data;
        }

    }
}
