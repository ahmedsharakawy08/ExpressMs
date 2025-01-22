using ExpressMs.Employees;
using ExpressMs.Recruitment;
using ExpressMs.RectuitmentCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Uow;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace ExpressMs.RecuruitmentApplication
{
    public class RecuruitmentApplicationAppService : ExpressMsAppService
    {
        private readonly IRepository<RecruitmentApplication> _recruitmentAppRepo;
        private readonly IdentityUserManager _userManager;
        private readonly IIdentityUserRepository _userRepo;
        private readonly IRepository<EmployeesData, Guid> _employeesRepo;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<PapersToUsers> _paperToUser;
        private readonly IRepository<EmployeesPapersTypes> _employeePaperType;
        public RecuruitmentApplicationAppService(IRepository<RecruitmentApplication> recruitmentAppRepo, IdentityUserManager userManager
            , IIdentityUserRepository userRepo, IRepository<EmployeesData, Guid> employeesRepo,
            IUnitOfWorkManager unitOfWorkManager, IRepository<PapersToUsers> paperToUser,
            IRepository<EmployeesPapersTypes> employeePaperType)
        {
            _recruitmentAppRepo = recruitmentAppRepo;
            _userManager = userManager;
            _userRepo = userRepo;
            _employeesRepo = employeesRepo;
            _unitOfWorkManager = unitOfWorkManager;
            _paperToUser = paperToUser;
            _employeePaperType = employeePaperType;
        }
        public async Task<RecruitmentApplication> CreateAsync(CreateRecruitmentApplicationDto input)
        {
            var data = ObjectMapper.Map<CreateRecruitmentApplicationDto, RecruitmentApplication>(input);
            var result = await _recruitmentAppRepo.InsertAsync(data);
            return result;
        }
        public async Task<RecruitmentApplication> UpdateAysnc(Guid Id, UpdateRecruitmentApplicationDto input)
        {
            var data = await _recruitmentAppRepo.GetAsync(obj => obj.Id == Id);
            var map = ObjectMapper.Map<UpdateRecruitmentApplicationDto, RecruitmentApplication>(input, data);
            var result = await _recruitmentAppRepo.UpdateAsync(map);
            return result;
        }
        public async Task DeleteAysc(Guid Id)
        {
            var data = await _recruitmentAppRepo.GetListAsync(obj => obj.Id == Id, true);
            await _recruitmentAppRepo.DeleteAsync(data.First(), true);
        }
        public async Task<List<RecruitmentApplicationDto>> GetListAsync()
        {
            var data = await _recruitmentAppRepo.GetListAsync(true);
            var dto = ObjectMapper.Map<List<RecruitmentApplication>, List<RecruitmentApplicationDto>>(data);
            return dto;
        }
        public async Task<RecruitmentApplicationDto> GetByIdAsyc(Guid Id)
        {
            var data = await _recruitmentAppRepo.FindAsync(obj => obj.Id == Id, true);
            return ObjectMapper.Map<RecruitmentApplication, RecruitmentApplicationDto>(data);
        }
        public async Task ApproveEmployee(Guid appId)
        {
            var App = await _recruitmentAppRepo.FindAsync(obj => obj.Id == appId, true);
            var users = await _userRepo.GetCountAsync();
            string usercode = (users + 1).ToString();

            IdentityUser user = new IdentityUser(Guid.NewGuid(), usercode, App.Email);
            user.Name = App.FullEnglishName;
            user.SetPhoneNumber(App.MobilePhone, true);
            user.SetIsActive(true);
            //  var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: false);
            var userAdded = await _userManager.CreateAsync(user, "@Aa" + App.NationalID);
            // await uow.CompleteAsync();
            EmployeesData emp = new EmployeesData()
            {
                Email = App.Email,
                FullEnglishName = App.FullEnglishName,
                FullArabicName = App.FullArabicName,
                ApplicationId = appId,
                BasicSalary = App.SalaryDetails.BasicSalary,
                BirthDate = App.BirthDate,
                Code = usercode,
                CompanyNumber = App.InsuranceData.CompanyNumber,
                DeflictPercent = App.InsuranceData.DeflictPercent,
                DeflictStartDate = App.InsuranceData.DeflictStartDate,
                DirectManager = App.DirectManager,
                Gender = App.Gender,
                FormType = App.FormType,
                GrossSalary = App.InsuranceData.GrossSalary,
                HomePhone = App.HomePhone,
                HouseAllowance = App.SalaryDetails.HouseAllowance,
                KidsNumber = App.KidsNumber,
                MartialStatus = App.MartialStatus,
                MobilePhone = App.MobilePhone,
                InsuranceNumber = App.InsuranceData.InsuranceNumber,
                NationalID = App.NationalID,
                Nationality = App.Nationality,
                OtherAllowances = App.SalaryDetails.OtherAllowances,
                PositionId = App.PositionId,
                RelationToBussinessOwner = App.InsuranceData.RelationToBussinessOwner,
                TotalSalary = App.SalaryDetails.TotalSalary,
                WhatsappPhone = App.WhatsappPhone,
                InsuranceType = App.InsuranceData.Type,
                UserId = user.Id,
                Company = App.Company,
                HiringDate=App.ActualStartDate

            };
            var existEmp = _employeesRepo.GetAsync(obj => obj.UserId == user.Id);
            if (existEmp == null)
                await _employeesRepo.InsertAsync(emp);

            App.Hired = true;
            await _recruitmentAppRepo.UpdateAsync(App);

            var paperTypes = await _employeePaperType.GetListAsync();
            List<PapersToUsers> papersList = new List<PapersToUsers>();
            foreach (var paperType in paperTypes)
            {
                var paper = new PapersToUsers(user.Id, paperType.Id, false, "");
                papersList.Add(paper);

            }
            await _paperToUser.InsertManyAsync(papersList);

        }

    }
}
