using ExpressMs.Employees;
using ExpressMs.Recruitment;
using ExpressMs.RectuitmentCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace ExpressMs.Users
{
    public class EmployeesAppService : ExpressMsAppService
    {
        private readonly IRepository<EmployeesData,Guid> _employeesRepo;
        public EmployeesAppService(IRepository<EmployeesData, Guid> employeesRepo)
        {
            _employeesRepo = employeesRepo;
        }
        public async Task<EmployeesDataDto>GetEmployeeByIdAsync(Guid  Id)
        {
            var Employee = await _employeesRepo.GetAsync(obj => obj.UserId == Id,true);
            var data = ObjectMapper.Map<EmployeesData,EmployeesDataDto >(Employee);
            return data;
        }
        public async Task<List<EmployeesDataDto>> GetEmployeesListAsync()
        {
            var Employee = await _employeesRepo.GetListAsync(true);
            var data = ObjectMapper.Map<List<EmployeesData>, List<EmployeesDataDto>>(Employee);
            return data;
        }

    }
}
