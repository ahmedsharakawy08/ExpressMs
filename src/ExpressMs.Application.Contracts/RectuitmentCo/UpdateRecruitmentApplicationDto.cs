using ExpressMs.Recruitment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressMs.RectuitmentCo
{
    public class UpdateRecruitmentApplicationDto
    {
        [Required]
        public string FullEnglishName { set; get; }
        [Required]
        public string FullArabicName { get; set; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string NationalID { set; get; }
        [Required]
        public string HomePhone { set; get; }
        [Required]
        public string MobilePhone { set; get; }
        [Required]
        public string WhatsappPhone { set; get; }

        public Gender? Gender { set; get; }
        public FormType? FormType { set; get; }
        [Required]
        public DateTime BirthDate { set; get; }
        [Required]
        public MartialStatus MartialStatus { set; get; }
        [Required]
        public Guid PositionId { set; get; }
        public List<ApplicationEducationDto> ApplicationEducations { set; get; }
        public int NoticePeriod { set; get; }
        public double ExpectedSalary { set; get; }
        public bool ExExpress_Employees { set; get; }
        public bool HaveRelatives { set; get; }
        public string HowDidyouHear { set; get; }
        public Guid DirectManager { set; get; }
        public string NationalIdPlace { set; get; }
        public string NationalIdDate { set; get; }
        public string Nationality { set; get; }
        public int KidsNumber { set; get; }
        public DateTime DateToRecieveDocs { set; get; }
        public double SafetyResult { set; get; }
        public DateTime ActualStartDate { set; get; }
        public int ContractPeriod { set; get; }//in months
        public DateTime ToStartAt { set; get; }
        public AppFinalDecision FinalDecision { set; get; }
        public List<ApplicationTrainingDto> ApplicationTrainings { set; get; }
        public List<ApplicationWorkExperieceDto> ApplicationWorkExperieces { set; get; }
        public List<ComputerLanguageSkillsDto> ComputerLanguageSkills { set; get; }
        public List<ApplicationRefrenceDto> ApplicationRefrence { set; get; }
        public List<CompanyRelationDtos> CompanyRelations { set; get; }
        public ApplicationAddressDataDto ApplicationAddressData { get; set; }
    }
}
