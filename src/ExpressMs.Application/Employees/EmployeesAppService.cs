using ExpressMs.Employees;
using ExpressMs.Recruitment;
using ExpressMs.RectuitmentCo;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;

namespace ExpressMs.Users
{
    public class EmployeesAppService : ExpressMsAppService
    {
        private readonly IRepository<EmployeesData, Guid> _employeesRepo;
        private readonly IRepository<RecruitmentApplication> _recruitmentAppRepo;
        private readonly IRepository<Department> _deptRepo;
        private readonly IRepository<Position> _posRepo;
        private readonly IIdentityUserRepository _userRepo;
        private readonly IdentityUserManager _userManager;
        private readonly IRepository<EmployeesPapersTypes> _employeePaperType;
        private readonly IRepository<PapersToUsers> _papersToUsers;
        public EmployeesAppService(
            IRepository<EmployeesData, Guid> employeesRepo
            , IRepository<RecruitmentApplication> recruitmentAppRepo,
            IIdentityUserRepository userRepo,
            IdentityUserManager userManager,
          IRepository<EmployeesPapersTypes> employeePaperType,
          IRepository<PapersToUsers> papersToUsers,
            IRepository<Department> deptRepo,
            IRepository<Position> posRepo)
        {
            _employeesRepo = employeesRepo;
            _recruitmentAppRepo = recruitmentAppRepo;
            _userRepo = userRepo;
            _userManager = userManager;
          _employeePaperType = employeePaperType;
          _papersToUsers = papersToUsers;
            _posRepo= posRepo;
            _deptRepo= deptRepo;

        }
        public async Task<EmployeesDataDto> GetEmployeeByIdAsync(Guid Id)
        {
            var employee = await _employeesRepo.GetAsync(obj => obj.UserId == Id, true);
            var data = ObjectMapper.Map<EmployeesData, EmployeesDataDto>(employee);
            return data;
        }
        public async Task<List<EmployeesDataDto>> GetEmployeeByComanyId(Guid companyId)
        {
            var employee = await _employeesRepo.GetListAsync();
            var departments = await _deptRepo.GetListAsync(obj => obj.CompanyId == companyId);
            var positions = departments.SelectMany(obj => obj.Positions).Select(obj => obj.Id).ToList();
            employee = employee.Where(obj => positions.Contains(obj.PositionId)).ToList();
            var data = ObjectMapper.Map<List<EmployeesData>, List<EmployeesDataDto>>(employee);
            return data;
        }
        public async Task<List<EmployeesDataDto>> GetEmployeeByDepartmentId(Guid deptId)
        {
            var employee = await _employeesRepo.GetListAsync();
            var departments = await _deptRepo.GetListAsync(obj => obj.Id == deptId);
            var positions = departments.SelectMany(obj => obj.Positions).Select(obj => obj.Id).ToList();
            employee = employee.Where(obj => positions.Contains(obj.PositionId)).ToList();
            var data = ObjectMapper.Map<List<EmployeesData>, List<EmployeesDataDto>>(employee);
            return data;
        }

        public async Task<List<EmployeesDataDto>> GetEmployeesListAsync()
        {
            var Employee = await _employeesRepo.GetListAsync(true);
            var data = ObjectMapper.Map<List<EmployeesData>, List<EmployeesDataDto>>(Employee);
            return data;
        }

        public async Task DeactivateEmployee(Guid userId, Guid appId)
        {
            var app = await _recruitmentAppRepo.GetAsync(obj => obj.Id == appId);
            var employee = await _employeesRepo.GetAsync(obj => obj.Id == userId, true);
            employee.Users.SetIsActive(false);
            await _employeesRepo.DeleteAsync(employee);
            app.Hired = false;
            await _recruitmentAppRepo.UpdateAsync(app);
        }

        public async Task UpdateUser(EditUserDto input)
        {
            _employeesRepo.DisableTracking();
            var employee = await _employeesRepo.GetAsync(obj => obj.Id == input.UserId, true);
            var empMap = ObjectMapper.Map<EditUserDto, EmployeesData>(input);
            var user = await _userRepo.GetAsync(input.UserId);
            var userMap = ObjectMapper.Map<EditUserDto, IdentityUser>(input);
            await _employeesRepo.UpdateAsync(empMap);
            await _userRepo.UpdateAsync(userMap);
        }
        public async Task AddUsersList(List<CreateUserDto> input)
        {
            var paperTypes = await _employeePaperType.GetListAsync();
            List<PapersToUsers> papersList = new List<PapersToUsers>();
            var data = ObjectMapper.Map<List<CreateUserDto>, List<EmployeesData>>(input);
            foreach (var usertocreate in input)
            {
                var users = await _userRepo.GetCountAsync();
                string usercode = (users + 1).ToString();
                IdentityUser user = new IdentityUser(Guid.NewGuid(), usercode, usertocreate.Email);
                user.Name = usertocreate.FullEnglishName;
                user.SetPhoneNumber(usertocreate.MobilePhone, true);
                user.SetIsActive(true);
                var userAdded = await _userManager.CreateAsync(user, "@Aa" + usertocreate.NationalID);

                foreach (var paperType in paperTypes)
                {
                    var paper = new PapersToUsers(user.Id, paperType.Id, false, "");
                    papersList.Add(paper);
                }
            }
            await _employeesRepo.InsertManyAsync(data);
            await _papersToUsers.InsertManyAsync(papersList);
        }
    }
}