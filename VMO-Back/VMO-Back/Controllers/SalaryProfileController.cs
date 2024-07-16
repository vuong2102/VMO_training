using AutoMapper;
using Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Model;
using Share;
using System;
using VMO_Back.Repository.Implement;
using VMO_Back.Repository.Interface;
using static Service.IService.IEmployeeService;
using static Service.IService.ISalaryProfileService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VMO_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryProfileController : ControllerBase
    {
        readonly ILogger<SalaryProfileController> _logger;
        readonly ISalaryProfileRepository _salaryProfileRepository;
        readonly IEmployeeRepository _employeeRepository;
        readonly IDepartmentRepository _departmentRepository;
        readonly ITitleRepository _titleRepository;
        readonly IMapper _mapper;

        public SalaryProfileController(ILogger<SalaryProfileController> logger,
            IMapper mapper,
            ISalaryProfileRepository SalaryProfileRepository,
            IEmployeeRepository EmployeeRepository,
            IDepartmentRepository DepartmentRepository,
            ITitleRepository TitleRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _salaryProfileRepository = SalaryProfileRepository;
            _employeeRepository = EmployeeRepository;
            _departmentRepository = DepartmentRepository;
            _titleRepository = TitleRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ExcuteResult<ListSalaryProfileResult>> GetAllAsync()
        {
            try
            {
                SalaryProfileSearch model = new SalaryProfileSearch
                {
                    Page = new Share.Domain.Page
                    {
                        PageIndex = 0,
                        PageSize = 15
                    },
                    Status = Model.Utils.ActiveStatus.All
                };
                var filter = model.CreateFilter(_salaryProfileRepository.GetQueryable());
                var data = await _salaryProfileRepository.ExecuteWithTransactionAsync(filter);

                var result = new ListSalaryProfileResult
                {
                    Data = _mapper.Map<List<SalaryProfileDto>>(data),
                    Total = data.Count,
                };

                return new ExcuteResult<ListSalaryProfileResult>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ListSalaryProfileResult>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ExcuteResult<SalaryProfileAddDto>> AddSalaryProfile(SalaryProfileAddDto dto)
        {
            try
            {
                var salaryProfile = _mapper.Map<SalaryProfile>(dto);
                if (dto.Benefits.IsNotNullOrEmpty())
                {
                    foreach (var item in dto.Benefits)
                    {
                        var benefitItem = _mapper.Map<Benefit>(item);
                        salaryProfile.BenefitSalaryProfiles.Add(
                            new BenefitSalaryProfile
                            {
                                BenefitSalaryProfileId = Guid.NewGuid().ToString(),
                                BenefitId = benefitItem.BenefitId,
                                Benefit = null,
                                SalaryProfileId = salaryProfile.SalaryProfileId,
                                SalaryProfile = null,
                                CreateDate = DateTime.Now,
                                Status = Model.Utils.ActiveStatus.Active
                            });
                    }
                }
                if (dto.Allowances.IsNotNullOrEmpty())
                {
                    foreach (var item in dto.Allowances)
                    {
                        var allowanceItem = _mapper.Map<Allowance>(item);
                        salaryProfile.AllowanceSalaryProfiles.Add(
                            new AllowanceSalaryProfile
                            {
                                AllowanceSalaryProfileId = Guid.NewGuid().ToString(),
                                AllowanceId = allowanceItem.AllowanceId,
                                Allowance = null,
                                SalaryProfileId = salaryProfile.SalaryProfileId,
                                SalaryProfile = null, 
                                CreateDate = DateTime.Now,
                                Status = Model.Utils.ActiveStatus.Active
                        });
                    }
                }

                var result = await _salaryProfileRepository.AddEntityAsync(salaryProfile);
                if (!result)
                {
                    return new NotFoundRecordResult<SalaryProfileAddDto>("Không có hồ sơ lương");
                }
                return new ExcuteResult<SalaryProfileAddDto>(dto, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<SalaryProfileAddDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }
    }
}
