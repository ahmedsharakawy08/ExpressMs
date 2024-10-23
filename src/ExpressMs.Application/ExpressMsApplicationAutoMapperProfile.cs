using AutoMapper;
using ExpressMs.Payroll.Dtos;
using ExpressMs.PayrollEntities;
using ExpressMs.Recruitment;
using ExpressMs.RectuitmentCo;

namespace ExpressMs;

public class ExpressMsApplicationAutoMapperProfile : Profile
{
    public ExpressMsApplicationAutoMapperProfile()
    {

        CreateMap<PayrollPayslipDto, PayrollPaySlip>();
        CreateMap<CreateRecruitmentApplicationDto, RecruitmentApplication>();
        CreateMap<UpdateRecruitmentApplicationDto, RecruitmentApplication>();
        CreateMap<ApplicationTrainingDto, ApplicationTraining>().ReverseMap();
        CreateMap<ApplicationWorkExperieceDto, ApplicationWorkExperiece>().ReverseMap();
        CreateMap<ComputerLanguageSkillsDto, ComputerLanguageSkills>().ReverseMap();
        CreateMap<ApplicationRefrenceDto, ApplicationRefrence>().ReverseMap();
        CreateMap<CompanyRelationDtos, CompanyRelations>().ReverseMap();
        CreateMap<ApplicationAddressDataDto, ApplicationAddressData>().ReverseMap();
        CreateMap<ApplicationEducationDto, RecruitmentApplicationEducation>().ReverseMap();
        CreateMap<RecruitmentApplication, RecruitmentApplicationDto>();
        
    }
}
