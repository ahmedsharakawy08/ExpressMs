using ExpressMs.Employees;
using ExpressMs.Recruitment;
using ExpressMs.RectuitmentCo;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace ExpressMs.RecuruitmentApplication
{
    public class RecuruitmentApplicationAppService : ExpressMsAppService
    {
        private readonly IRepository<RecruitmentApplication> _recruitmentAppRepo;
        private readonly IdentityUserManager _userManager;
        private readonly IIdentityUserRepository _userRepo;
        private readonly IRepository<EmployeesData, Guid> _employeesRepo;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public RecuruitmentApplicationAppService(IRepository<RecruitmentApplication> recruitmentAppRepo, IdentityUserManager userManager
            , IIdentityUserRepository userRepo, IRepository<EmployeesData, Guid> employeesRepo, IUnitOfWorkManager unitOfWorkManager)
        {
            _recruitmentAppRepo = recruitmentAppRepo;
            _userManager = userManager;
            _userRepo = userRepo;
            _employeesRepo= employeesRepo;
            _unitOfWorkManager = unitOfWorkManager;
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
            var data= await _recruitmentAppRepo.GetListAsync(true);
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
            var users = await _userRepo.GetCountAsync();
            var App = await _recruitmentAppRepo.FindAsync(obj => obj.Id == appId, true);
            string usercode = (users + 1).ToString();
 
                IdentityUser user = new IdentityUser(Guid.NewGuid(), usercode, App.Email);
                user.Name = App.FullEnglishName;                    
                user.SetPhoneNumber(App.MobilePhone, true);
                user.SetIsActive(true);
             //  var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: false);
                var userAdded=  await _userManager.CreateAsync(user,"@Aa"+App.NationalID);
           // await uow.CompleteAsync();
            EmployeesData emp=new EmployeesData()
               {
                   Email = App.Email,
                   FullEnglishName = App.FullEnglishName,
                   FullArabicName = App.FullArabicName,
                   ApplicationId = appId,
                   BasicSalary=App.SalaryDetails.BasicSalary,
                   BirthDate = App.BirthDate,
                   Code=usercode,
                   CompanyNumber=App.InsuranceData.CompanyNumber,
                   DeflictPercent=App.InsuranceData.DeflictPercent,
                   DeflictStartDate=App.InsuranceData.DeflictStartDate,
                   DirectManager= App.DirectManager,
                   Gender=App.Gender,
                   FormType=App.FormType,
                   GrossSalary = App.InsuranceData.GrossSalary,
                   HomePhone=App.HomePhone,
                   HouseAllowance=App.SalaryDetails.HouseAllowance,
                   KidsNumber= App.KidsNumber,
                   MartialStatus= App.MartialStatus,
                   MobilePhone=App.MobilePhone,
                   InsuranceNumber= App.InsuranceData.InsuranceNumber,
                   NationalID=App.NationalID,
                   Nationality=App.Nationality,
                   OtherAllowances=App.SalaryDetails.OtherAllowances,
                   PositionId=App.PositionId,
                   RelationToBussinessOwner= App.InsuranceData.RelationToBussinessOwner,
                   TotalSalary=App.SalaryDetails.TotalSalary,
                   WhatsappPhone=App.WhatsappPhone,
                   InsuranceType=App.InsuranceData.Type,
                   UserId= user.Id
                  
               };
               await  _employeesRepo.InsertAsync(emp);

                // TODO create entity of employees data with email
            
            App.Hired = true;
            await _recruitmentAppRepo.UpdateAsync(App);
         
        }

    } 
}
