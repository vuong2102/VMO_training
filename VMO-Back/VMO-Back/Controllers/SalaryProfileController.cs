using AutoMapper;
using Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Model;
using Share;
using System;
using VMO_Back.Repository.Implement;
using VMO_Back.Repository.Interface;
using static Service.IService.IAllowanceService;
using static Service.IService.IEmployeeService;
using static Service.IService.ISalaryProfileAllowanceService;
using static Service.IService.ISalaryProfileBenefitService;
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
        readonly ISalaryProfileAllowanceRepository _salaryProfileAllowanceRepository;
        readonly ISalaryProfileBenefitRepository _salaryProfileBenefitRepository;
        readonly IAllowanceRepository _allowanceRepository;
        readonly IBenefitRepository _benefitRepository;
        readonly IEmployeeRepository _employeeRepository;
        readonly IDepartmentRepository _departmentRepository;
        readonly ITitleRepository _contractRepository;
        readonly IMapper _mapper;

        public SalaryProfileController(ILogger<SalaryProfileController> logger,
            IMapper mapper,
            ISalaryProfileRepository SalaryProfileRepository,
            IEmployeeRepository EmployeeRepository,
            IDepartmentRepository DepartmentRepository,
            ITitleRepository TitleRepository,
            ISalaryProfileAllowanceRepository SalaryProfileAllowanceRepository,
            ISalaryProfileBenefitRepository SalaryProfileBenefitRepository,
            IAllowanceRepository AllowanceRepository,
            IBenefitRepository BenefitRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _salaryProfileRepository = SalaryProfileRepository;
            _employeeRepository = EmployeeRepository;
            _departmentRepository = DepartmentRepository;
            _contractRepository = TitleRepository;
            _salaryProfileAllowanceRepository = SalaryProfileAllowanceRepository;
            _salaryProfileBenefitRepository = SalaryProfileBenefitRepository;
            _allowanceRepository = AllowanceRepository;
            _benefitRepository = BenefitRepository;
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

                foreach (var item in result.Data)
                {
                    SalaryProfileAllowanceSearch modelAllowance = new SalaryProfileAllowanceSearch
                    {
                        SalaryProfileId = item.SalaryProfileId,
                        Status = Model.Utils.ActiveStatus.All
                    };
                    var filterAllowance = modelAllowance.CreateFilter(_salaryProfileAllowanceRepository.GetQueryable());
                    var dataAllowanceList = await _salaryProfileAllowanceRepository.ExecuteWithTransactionAsync(filterAllowance);
                    var listAllowanceDto = new List<AllowanceDto>();
                    foreach(var itemAllowance in dataAllowanceList)
                    {
                        var allowance = await _allowanceRepository.GetAsync(c => c.AllowanceId == itemAllowance.AllowanceId);
                        listAllowanceDto.Add(_mapper.Map<AllowanceDto>(allowance));
                    }
                    item.Allowances = listAllowanceDto;

                    SalaryProfileBenefitSearch modelBenefit = new SalaryProfileBenefitSearch
                    {
                        SalaryProfileId = item.SalaryProfileId,
                        Status = Model.Utils.ActiveStatus.All
                    };
                    var filterBenefit = modelBenefit.CreateFilter(_salaryProfileBenefitRepository.GetQueryable());
                    var dataBenefit = await _salaryProfileBenefitRepository.ExecuteWithTransactionAsync(filterBenefit);
                    var listBenefitDto = new List<BenefitDto>();
                    foreach (var itemBenefit in dataBenefit)
                    {
                        var benefit = await _benefitRepository.GetAsync(c => c.BenefitId == itemBenefit.BenefitId);
                        var benefitMap = _mapper.Map<BenefitDto>(benefit);
                        listBenefitDto.Add(benefitMap);
                    }
                    item.Benefits = listBenefitDto;
                }

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

        [HttpDelete]
        [Route("delete")]
        public async Task<ExcuteResult<bool?>> DeleteTitle(string id)
        {
            try
            {
                var result = await _salaryProfileRepository.DeleteAsync(id);
                if (!result)
                {
                    return new NotFoundRecordResult<bool?>("Không thể xóa hồ sơ lương");
                }
                return new ExcuteResult<bool?>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<bool?>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }
    }
}
