using ExpressMs.GenericEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExpressMs.Recruitment
{
    public class DataSeederContributor:IDataSeedContributor,ITransientDependency
    {
        private readonly IRepository<Governorate> _governorateRepo;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Department,Guid> _deptRepo;
        private readonly IRepository<Position, Guid> _posRepo;
        public DataSeederContributor(IRepository<Governorate> governorateRepo, IRepository<City> cityRepository,
            IRepository<Department, Guid> deptRepo, IRepository<Position, Guid> posRepo)
        {
            _governorateRepo = governorateRepo;
            _cityRepository = cityRepository;
            _deptRepo= deptRepo;
            _posRepo=posRepo;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            await _governorateRepo.DeleteAsync(obj => obj.GovernorateNameEn != "");
            var governorates = new List<Governorate>() { new Governorate("القاهرة", "Cairo") };
            var cities = new List<City>() { new City ("15 مايو") };
            await  _governorateRepo.InsertManyAsync(governorates);
            await _cityRepository.InsertManyAsync(cities);
           await  seedDeptPosAsync();

        }
        public async Task seedDeptPosAsync()
        {

                // Define departments and their positions
                var departments = new List<Department>
        {
            new Department { Name = "الإدارة العليا", Positions = new List<Position>
                {
                    new Position { Name = "CEO" },
                    new Position { Name = "General Manager" }
                }
            },
            new Department { Name = "الشئون القانونية", Positions = new List<Position>
                {
                    new Position { Name = "Legal Affairs Manager" },
                    new Position { Name = "Legal affairs specialist" }
                }
            },
            new Department { Name = "المالية", Positions = new List<Position>
                {
                    new Position { Name = "Financial Manager" },
                    new Position { Name = "Accountant" }
                }
            },
            new Department { Name = "الموارد البشرية", Positions = new List<Position>
                {
                    new Position { Name = "HR Manager" },
                    new Position { Name = "HR specialist" },
                    new Position { Name = "Admin specialist" },
                    new Position { Name = "Buffet worker" }
                }
            },
            new Department { Name = "التسويق و المبيعات", Positions = new List<Position>
                {
                    new Position { Name = "Marketing and sales Manager" },
                    new Position { Name = "Marketing and sales specialist" },
                    new Position { Name = "Sales representative" }
                }
            },
            new Department { Name = "المشتريات", Positions = new List<Position>
                {
                    new Position { Name = "Procurement Manager" },
                    new Position { Name = "Procurement Specialist" },
                    new Position { Name = "Procurement representative" }
                }
            },
            new Department { Name = "المشروعات", Positions = new List<Position>
                {
                    new Position { Name = "Projects manager" },
                    new Position { Name = "Projects Engineer" },
                    new Position { Name = "Site engineer" },
                    new Position { Name = "Electrical Engineer" },
                    new Position { Name = "Mechanical engineer" },
                    new Position { Name = "Civil engineer" },
                    new Position { Name = "Architectural engineer" },
                    new Position { Name = "General supervisor" },
                    new Position { Name = "Plumber technician" },
                    new Position { Name = "Plumber Helper" },
                    new Position { Name = "Carpenter technician" },
                    new Position { Name = "Carpenter Helper" },
                    new Position { Name = "Aluminum technician" },
                    new Position { Name = "Aluminum technician Helper" },
                    new Position { Name = "Painting technician" },
                    new Position { Name = "Painter Helper" },
                    new Position { Name = "Electrical technician" },
                    new Position { Name = "Electrician Helper" },
                    new Position { Name = "Refrigeration and air conditioning technician" },
                    new Position { Name = "Refrigeration and air conditioning technician Helper" },
                    new Position { Name = "Grind fitter technician" },
                    new Position { Name = "Grind fitter Helper" },
                    new Position { Name = "Welder technician" },
                    new Position { Name = "Welder Helper" },
                    new Position { Name = "General fitter technician" },
                    new Position { Name = "General fitter technician Helper" },
                    new Position { Name = "Cleaning Supervisor" },
                    new Position { Name = "Cleaning Worker" }
                }
            },
            new Department { Name = "السلامة و الصحة المهنية", Positions = new List<Position>
                {
                    new Position { Name = "HSE Manager" },
                    new Position { Name = "HSE Supervisor" },
                    new Position { Name = "HSE Specialist" }
                }
            },
            new Department { Name = "الجودة", Positions = new List<Position>
                {
                    new Position { Name = "Internal Audit Director" },
                    new Position { Name = "Quality Assurance Manager" },
                    new Position { Name = "Quality Control Manager" },
                    new Position { Name = "Quality Assurance Specialist" },
                    new Position { Name = "Quality Control Specialist" },
                    new Position { Name = "Internal audit Specialist" }
                }
            }
        };

                // Add departments and their positions if not already present
                foreach (var department in departments)
                {
                    // Check if the department already exists
                    var existingDept = (await _deptRepo.GetListAsync()).FirstOrDefault(d => d.Name == department.Name);

                    if (existingDept == null)
                    {
                        // Add new department
                        await _deptRepo.InsertAsync(department);
                        existingDept = department;
                    }

                    // Add positions for the department if not already present
                    foreach (var position in department.Positions)
                    {
                        var existingPos = (await _posRepo.FirstOrDefaultAsync(p => p.Name == position.Name && p.DepartmentId == existingDept.Id));
                        if (existingPos == null)
                        {
                            position.DepartmentId = existingDept.Id; // Associate the position with the department
                            await _posRepo.InsertAsync(position);
                        }
                    }
                }
            }
        }

    }
