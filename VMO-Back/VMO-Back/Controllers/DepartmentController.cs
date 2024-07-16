using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Model;
using Share;
using VMO_Back.Repository.Implement;
using VMO_Back.Repository.Interface;
using static Service.IService.IDepartmentService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VMO_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        readonly ILogger<DepartmentController> _logger;
        readonly IDepartmentRepository _departmentRepository;
        readonly IMapper _mapper;

        public DepartmentController(ILogger<DepartmentController> logger,
            IMapper mapper,
            IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ExcuteResult<ListDepartmentResult>> GetAllDepartmentAsync()
        {
            try
            {
                DepartmentSearch model = new DepartmentSearch
                {
                    Page = new Share.Domain.Page
                    {
                        PageIndex = 0,
                        PageSize = 15
                    }
                };
                var filter = model.CreateFilter(_departmentRepository.GetQueryable());
                var data = await _departmentRepository.ExecuteWithTransactionAsync(filter);
                var result = new ListDepartmentResult
                {
                    Data = _mapper.Map<List<DepartmentDto>>(data),
                    Total = 0,
                };
                return new ExcuteResult<ListDepartmentResult>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ListDepartmentResult>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpGet]
        [Route("detail")]
        public async Task<ExcuteResult<DepartmentDto>> GetDepartmentByIdAsync(string id)
        {
            try
            {
                var result = await _departmentRepository.GetAsync(c => c.DepartmentId == id);
                if (result == null)
                {
                    return new NotFoundRecordResult<DepartmentDto>("Không thể thêm phòng ban");
                }
                var department = _mapper.Map<DepartmentDto>(result);
                return new ExcuteResult<DepartmentDto>(department, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<DepartmentDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ExcuteResult<DepartmentAddDto>> AddDepartment(DepartmentAddDto dto)
        {
            try
            {
                
                var department = _mapper.Map<Department>(dto);
                var result = await _departmentRepository.AddEntityAsync(department);
                if (!result)
                {
                    return new NotFoundRecordResult<DepartmentAddDto>("Không thể thêm phòng ban");
                }
                return new ExcuteResult<DepartmentAddDto>(dto, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<DepartmentAddDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<ExcuteResult<bool?>> UpdateAsync(DepartmentUpdateDto model)
        {
            try
            {
                _departmentRepository.BeginTransaction();
                var existEntity = await _departmentRepository.GetAsync(c => c.DepartmentId == model.DepartmentId);
                var department = _mapper.Map(model, existEntity);

                await _departmentRepository.UpdateEntityAsync(department, false);
                var updateResult = await _departmentRepository.CommitTransactionAsync();
                if (!updateResult)
                {
                    return new NotFoundRecordResult<bool?>("Không thể cập nhật phòng ban");
                }
                return new ExcuteResult<bool?>(updateResult, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<bool?>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ExcuteResult<bool?>> DeleteDepartment(string id)
        {
            try
            {
                var result = await _departmentRepository.DeleteAsync(id);
                if (!result)
                {
                    return new NotFoundRecordResult<bool?>("Không thể xóa phòng ban");
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
