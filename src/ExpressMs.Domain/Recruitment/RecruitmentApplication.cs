using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
namespace ExpressMs.Recruitment
{

    public class RecruitmentApplication : FullAuditedAggregateRoot<Guid>
    {
        public string? FullEnglishName { set; get; }
        public string? FullArabicName { get; set; }
        public string? Email { set; get; }
        public string? NationalID { set; get; }
        public string? HomePhone { set; get; }
        public string? MobilePhone { set; get; }
        public string? WhatsappPhone { set; get; }
        public Gender Gender { set; get; }
        public FormType FormType { set; get; }
        public DateTime BirthDate { set; get; }
        public MartialStatus MartialStatus { set; get; }

        [ForeignKey("Position")]
        public Guid PositionId { set; get; }
        public virtual Position Positions { set; get; }
        public ICollection<RecruitmentApplicationEducation> ApplicationEducations { set; get; }
        public int NoticePeriod { set; get; }
        public double ExpectedSalary { set; get; }
        public bool ExExpress_Employees { set; get; }
        public bool HaveRelatives { set; get; }
        public string HowDidyouHear { set; get; }
        public DateTime ToStartAt { set; get; }
        public AppFinalDecision FinalDecision { set; get; }
        public ICollection<ApplicationTraining> ApplicationTrainings { set; get; }
        public ICollection<ApplicationWorkExperiece> ApplicationWorkExperieces { set; get; }
        public ICollection<ComputerLanguageSkills> ComputerLanguageSkills { set; get; }
        public ICollection<ApplicationRefrence> ApplicationRefrence { set; get; }
        public ICollection<CompanyRelations> CompanyRelations { set; get; }
        public virtual ApplicationAddressData ApplicationAddressData { get; set; }

        public RecruitmentApplication() {

            ApplicationEducations = new HashSet<RecruitmentApplicationEducation>();
            ApplicationTrainings = new HashSet<ApplicationTraining>();
            ApplicationWorkExperieces= new HashSet<ApplicationWorkExperiece>();
            ComputerLanguageSkills= new HashSet<ComputerLanguageSkills>();
            ApplicationRefrence=new HashSet<ApplicationRefrence>();
            CompanyRelations=new HashSet<CompanyRelations>();   

        }

        
    }
}
