using ExpressMs.Recruitment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ExpressMs.Settings
{
    public class DepartmentPositionAppService : ExpressMsAppService
    {
        private readonly IRepository<Department,Guid> _departmentRepo;
        private readonly IRepository<Position,Guid> _positionRepo;
        public DepartmentPositionAppService(IRepository<Department, Guid> departmentRepo,
            IRepository<Position, Guid> positionRepo)
        {
            _departmentRepo = departmentRepo;
            _positionRepo = positionRepo;
        }
        public async Task CreateDepartmentAsync(string name)
        {
            var departmant = new Department();
            departmant.Name = name;
            await _departmentRepo.InsertAsync(departmant);
        }
        public async Task CreatepositionAsync(Guid  deptId,string name)
        {
            var position = new Position();
            position.Name = name;
            position.DepartmentId = deptId;
            await _positionRepo.InsertAsync(position);
        }
        public async Task<List<Department>> GetDepartments()
        {
            return await _departmentRepo.GetListAsync(true);
        }
    }
}
