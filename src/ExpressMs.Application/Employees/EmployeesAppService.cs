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
        private readonly IRepository<RecruitmentApplication> _recruitmentAppRepo;
        public EmployeesAppService(IRepository<EmployeesData, Guid> employeesRepo
            , IRepository<RecruitmentApplication> recruitmentAppRepo)
        {
            _employeesRepo = employeesRepo;
            _recruitmentAppRepo = recruitmentAppRepo;
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

        public async Task DeactIvateEmployee(Guid userId, Guid appId)
        {
            var app = await _recruitmentAppRepo.GetAsync(obj => obj.Id == appId);
            var employee = await _employeesRepo.GetAsync(obj => obj.Id == userId, true);
            employee.Users.SetIsActive(false);
            await _employeesRepo.DeleteAsync(employee);
            app.Hired = false;
            await _recruitmentAppRepo.UpdateAsync(app);
        }

    }
}
