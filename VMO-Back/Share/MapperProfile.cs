using AutoMapper;
using Model.Model;
using Model.DTO;
using Core.Extensions;

namespace Share
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeAddDto, Employee>()
                .ForMember(src => src.EmployeeId, dest => dest.MapFrom(c => ObjectExtentions.GenerateGuid()))
                .ReverseMap();

            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<DepartmentAddDto, Department>()
                .ForMember(src => src.DepartmentId, dest => dest.MapFrom(c => ObjectExtentions.GenerateGuid()))
               .ReverseMap();
            CreateMap<DepartmentUpdateDto, Department>().ReverseMap();
            
            //Title
            CreateMap<Title, TitleDto>().ReverseMap();
            CreateMap<Title, TitleDetailDto>().ReverseMap();
            CreateMap<TitleAddDto, Title>()
                .ForMember(src => src.TitleId, dest => dest.MapFrom(c => ObjectExtentions.GenerateGuid()))
                .ReverseMap();
            CreateMap<TitleUpdateDto, Title>().ReverseMap();
            CreateMap<string, TitleCodeMax>()
                .ForMember(dest => dest.TitleCode, opt => opt.MapFrom(src => src));

            //ContractType
            CreateMap<ContractType, ContractTypeDto>().ReverseMap();
            CreateMap<ContractTypeAddDto, ContractType>()
                .ForMember(src => src.ContractTypeId, dest => dest.MapFrom(c => ObjectExtentions.GenerateGuid()))
                .ReverseMap();
            CreateMap<ContractTypeUpdateDto, ContractType>().ReverseMap();

            //Contract
            CreateMap<Contract, ContractDto>().ReverseMap();
            CreateMap<ContractAddDto, Contract>()
                .ForMember(src => src.ContractId, dest => dest.MapFrom(c => ObjectExtentions.GenerateGuid()))
                .ReverseMap();
            CreateMap<ContractUpdateDto, Contract>().ReverseMap();

            //Salary Map
            CreateMap<SalaryProfile, SalaryProfileDto>().ReverseMap();
            CreateMap<SalaryProfileAddDto, SalaryProfile>()
                .ForMember(src => src.SalaryProfileId, dest => dest.MapFrom(c => ObjectExtentions.GenerateGuid()))
                .ReverseMap();
            CreateMap<SalaryProfileUpdateDto, SalaryProfile>().ReverseMap();


            //Benefit
            CreateMap<Benefit, BenefitDto>().ReverseMap();
            CreateMap<BenefitAddDto, Benefit>()
                .ForMember(src => src.BenefitId, dest => dest.MapFrom(c => ObjectExtentions.GenerateGuid()))
                .ReverseMap();
            CreateMap<BenefitUpdateDto, Benefit>().ReverseMap();

            CreateMap<BenefitSalaryProfile, BenefitSalaryProfileDto>().ReverseMap();
            CreateMap<BenefitSalaryProfileAddDto, BenefitSalaryProfile>().ReverseMap();
            CreateMap<BenefitSalaryProfileUpdateDto, Benefit>().ReverseMap();

            //Allowance
            CreateMap<Allowance, AllowanceDto>().ReverseMap();
            CreateMap<AllowanceAddDto, Allowance>()
                .ForMember(src => src.AllowanceId, dest => dest.MapFrom(c => ObjectExtentions.GenerateGuid()))
                .ReverseMap();
            CreateMap<AllowanceUpdateDto, Allowance>().ReverseMap();
            
            CreateMap<AllowanceSalaryProfile, AllowanceSalaryProfileDto>().ReverseMap();
            CreateMap<AllowanceSalaryProfileAddDto, AllowanceSalaryProfile>().ReverseMap();
            CreateMap<AllowanceSalaryProfileUpdateDto, AllowanceSalaryProfile>().ReverseMap();
        }
    }
}
