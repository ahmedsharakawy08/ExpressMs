using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ExpressMs.Employees
{
    public class PapersAppService : ExpressMsAppService
    {
        private readonly IRepository<EmployeesPapersTypes,Guid > _employeePaperType;
        private readonly IRepository<PapersToUsers,Guid > _paperToUser;
        public PapersAppService(IRepository<EmployeesPapersTypes,Guid > employeePaperType
            , IRepository<PapersToUsers,Guid > paperToUser)
        {
            _employeePaperType = employeePaperType;
            _paperToUser = paperToUser;
        }
        public async Task CreatePaperTypes(string type)
        {
          var EmployeesPapersTypes = new EmployeesPapersTypes(type);
          await _employeePaperType.InsertAsync(EmployeesPapersTypes);
        }
        public Task<List<EmployeesPapersTypes>> GetPapertypes()
        {
            var papersTypes = _employeePaperType.GetListAsync();
            return papersTypes;
        }
        public async Task AddPaperToUser(CreatePapersToUserDto input)
        {
            var paper = await _paperToUser.GetAsync(obj => obj.EmployeesPapersTypeId
                                            == input.EmployeesPapersTypeId && obj.UserId == input.UserId);

            paper.Content = input.Content;
            paper.Status = true;
            await _paperToUser.InsertAsync(paper);

        }
        public async Task<List<PapersToUserDto>> GetPaperOfUser(Guid UserId)
        {
            var paper = await _paperToUser.GetListAsync(obj=>obj.UserId== UserId);
            var data = ObjectMapper.Map<List<PapersToUsers>, List<PapersToUserDto>>(paper);
            return data;

        }
    }
}
