using ExpressMs.Recruitment;
using System;

namespace ExpressMs.Employees
{
    public class EmployeesDataDto
    {
        public Guid UserId { set; get; }
        public string? Code { set; get; }
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
        public Guid PositionId { set; get; }
        public Guid DirectManager { set; get; }
        public string Nationality { set; get; }
        public int KidsNumber { set; get; }
        public double BasicSalary { set; get; }
        public double HouseAllowance { set; get; }
        public double TransportationAllowance { set; get; }
        public double OtherAllowances { set; get; }
        public double TotalSalary { set; get; }
        public string InsuranceType { set; get; }
        public string CompanyNumber { set; get; }
        public string InsuranceNumber { set; get; }
        public DateTime SubscribedAt { set; get; }
        public double SubscribtionSalary { set; get; }
        public double GrossSalary { set; get; }
        public string RelationToBussinessOwner { set; get; }
        public DateTime DeflictStartDate { set; get; }
        public double DeflictPercent { set; get; }
        public Guid ApplicationId { set; get; }
    }
}
