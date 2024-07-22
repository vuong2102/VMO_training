using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Model;
using Share;
using VMO_Back.Repository.Implement;
using VMO_Back.Repository.Interface;
using static Service.IService.IAllowanceService;
using static Service.IService.IEmployeeService;
using static Service.IService.ITitleService;

namespace VMO_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly ILogger<EmployeeController> _logger;
        readonly IEmployeeRepository _employeeRepository;
        readonly IDepartmentRepository _departmentRepository;
        readonly ITitleRepository _contractRepository;
        readonly IMapper _mapper;

        public EmployeeController(
            ILogger<EmployeeController> logger,
            IMapper mapper,
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            ITitleRepository titleRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _contractRepository = titleRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ExcuteResult<ListEmployeeResult>> GetAllAsync()
        {
            try
            {
                EmployeeSearch model = new EmployeeSearch
                {
                    Page = new Share.Domain.Page
                    {
                        PageIndex = 0,
                        PageSize = 15
                    },
                    Status = Model.Utils.ActiveStatus.All
                };
                var filter = model.CreateFilter(_employeeRepository.GetQueryable());
                var data = await _employeeRepository.ExecuteWithTransactionAsync(filter);

                foreach (var item in data)
                {
                    item.Title = await _contractRepository.GetAsync(c => c.TitleId == item.TitleId);
                    item.Department = await _departmentRepository.GetAsync(c => c.DepartmentId == item.DepartmentId);
                }

                var result = new ListEmployeeResult
                {
                    Data = _mapper.Map<List<EmployeeDto>>(data),
                    Total = data.Count,
                };

                

                return new ExcuteResult<ListEmployeeResult>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ListEmployeeResult>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpGet]
        [Route("all-filter")]
        public async Task<ExcuteResult<ListEmployeeResult>> GetAllEmployeesByDepartmentAndTitleIdAsync(string departmentId, string titleId)
        {
            try
            {
                EmployeeSearch model = new EmployeeSearch
                {
                    Page = new Share.Domain.Page
                    {
                        PageIndex = 0,
                        PageSize = 15
                    },
                    DepartmentId = departmentId,
                    TitleId = titleId,       
                    Status = Model.Utils.ActiveStatus.All
                };
                var filter = model.CreateFilter(_employeeRepository.GetQueryable());
                var data = await _employeeRepository.GetAllWithFilterAsync(model);

                foreach (var item in data)
                {
                    item.Title = await _contractRepository.GetAsync(c => c.TitleId == item.TitleId);
                    item.Department = await _departmentRepository.GetAsync(c => c.DepartmentId == item.DepartmentId);
                }

                var result = new ListEmployeeResult
                {
                    Data = _mapper.Map<List<EmployeeDto>>(data),
                    Total = data.Count,
                };
                return new ExcuteResult<ListEmployeeResult>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ListEmployeeResult>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ExcuteResult<EmployeeAddDto>> AddEmployee(EmployeeAddDto dto)
        {
            try
            {
                var employee = _mapper.Map<Employee>(dto);
                var result = await _employeeRepository.AddEntityAsync(employee);
                if (!result)
                {
                    return new NotFoundRecordResult<EmployeeAddDto>("Không có nhân viên");
                }
                return new ExcuteResult<EmployeeAddDto>(dto, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<EmployeeAddDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpGet]
        [Route("detail/{id}")]
        public async Task<ExcuteResult<EmployeeDto>> GetEmployeeByIdAsync(string id)
        {
            try
            {
                var result = await _employeeRepository.GetAsync(c => c.EmployeeId == id);
                if (result == null)
                {
                    return new NotFoundRecordResult<EmployeeDto>("Không thể thêm phòng ban");
                }
                var employee = _mapper.Map<EmployeeDto>(result);
                var departmentData = await _departmentRepository.GetAsync(c => c.DepartmentId == result.DepartmentId);
                var titleData = await _contractRepository.GetAsync(c => c.TitleId == result.TitleId);

                employee.Department = _mapper.Map<DepartmentDto>(departmentData);
                employee.Title = _mapper.Map<TitleDetailDto>(titleData);

                return new ExcuteResult<EmployeeDto>(employee, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<EmployeeDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }
    }
}
