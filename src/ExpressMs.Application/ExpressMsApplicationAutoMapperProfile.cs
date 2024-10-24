﻿using AutoMapper;
using ExpressMs.Payroll.Dtos;
using ExpressMs.PayrollEntities;
using ExpressMs.Recruitment;
using ExpressMs.RectuitmentCo;
using System;

namespace ExpressMs;

public class ExpressMsApplicationAutoMapperProfile : Profile
{
    public ExpressMsApplicationAutoMapperProfile()
    {

        CreateMap<PayrollPayslipDto, PayrollPaySlip>();
        CreateMap<CreateRecruitmentApplicationDto, RecruitmentApplication>();
        CreateMap<UpdateRecruitmentApplicationDto, RecruitmentApplication>();
        CreateMap<ApplicationTrainingDto, ApplicationTraining>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ReverseMap(); 
        CreateMap<ApplicationWorkExperieceDto, ApplicationWorkExperiece>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ReverseMap(); 
        CreateMap<ComputerLanguageSkillsDto, ComputerLanguageSkills>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ReverseMap();
        CreateMap<ApplicationRefrenceDto, ApplicationRefrence>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ReverseMap();
        CreateMap<CompanyRelationDtos, CompanyRelations>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ReverseMap();
        CreateMap<ApplicationAddressDataDto, ApplicationAddressData>().ReverseMap();
        CreateMap<ApplicationEducationDto, RecruitmentApplicationEducation>()
       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ReverseMap(); 
        CreateMap<RecruitmentApplication, RecruitmentApplicationDto>();
        
    }
}
