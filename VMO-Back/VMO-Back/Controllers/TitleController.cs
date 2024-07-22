using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Model;
using Share;
using static Service.IService.ITitleService;
using VMO_Back.Repository.Interface;
using System.Text.RegularExpressions;
using Model.Utils;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;

namespace VMO_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        readonly ILogger<TitleController> _logger;
        readonly ITitleRepository _contractRepository;
        readonly IDepartmentRepository _departmentRepository;
        readonly IMapper _mapper;

        public TitleController(ILogger<TitleController> logger,
            IMapper mapper,
            ITitleRepository TitleRepository,
            IDepartmentRepository DepartmentRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _contractRepository = TitleRepository;
            _departmentRepository = DepartmentRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ExcuteResult<ListTitleResult>> GetAllTitleAsync()
        {
            try
            {
                TitleSearch model = new TitleSearch
                {
                    Page = new Share.Domain.Page
                    {
                        PageIndex = 0,
                        PageSize = 15
                    }
                };
                var filter = model.CreateFilter(_contractRepository.GetQueryable());
                var data = await _contractRepository.ExecuteWithTransactionAsync(filter);

                var result = new ListTitleResult
                {
                    Data = _mapper.Map<List<TitleDto>>(data),
                    Total = 0,
                };
                if (result.Data != null)
                {
                    foreach (var item in result.Data)
                    {
                        var resultDepartment = await _departmentRepository.GetAsync(c => c.DepartmentId == item.DepartmentId);
                        if (resultDepartment != null)
                        {
                            item.Department = _mapper.Map<DepartmentDto>(resultDepartment);
                        }
                    }
                }
                return new ExcuteResult<ListTitleResult>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ListTitleResult>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }
    
        [HttpGet]
        [Route("detail")]
        public async Task<ExcuteResult<TitleDto>> GetTitleByIdAsync(string id)
        {
            try
            {
                var result = await _contractRepository.GetAsync(c => c.TitleId == id);
                if (result == null)
                {
                    return new NotFoundRecordResult<TitleDto>("Không thể thêm phòng ban");
                }
                var Title = _mapper.Map<TitleDto>(result);
                return new ExcuteResult<TitleDto>(Title, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<TitleDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpGet]
        [Route("departmentId")]
        public async Task<ExcuteResult<ListTitleDetailResult>> GetAllTitleByDepartmentIdAsync(string id)
        {
            try
            {
                TitleSearch model = new TitleSearch
                {
                    Page = new Share.Domain.Page
                    {
                        PageIndex = 0,
                        PageSize = 15
                    },
                    DepartmentId = id,
                    Status = ActiveStatus.Active
                };
                var filter = model.CreateFilter(_contractRepository.GetQueryable());
                var data = await _contractRepository.ExecuteWithTransactionAsync(filter);

                var result = new ListTitleDetailResult
                {
                    Data = _mapper.Map<List<TitleDetailDto>>(data),
                    Total = 0,
                };
                return new ExcuteResult<ListTitleDetailResult>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ListTitleDetailResult>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpGet]
        [Route("titlecode-max")]
        public async Task<ExcuteResult<string>> GetTitleCodeMax()
        {
            try
            {
                var data = await _contractRepository.GetTitleCodeMax();
                Regex regex = new Regex(@"(CD)(0*)(\d+)");
                Match match = regex.Match(data);
                string result = "";
                if (match.Success)
                {
                    string prefix = match.Groups[1].Value;
                    string zeros = match.Groups[2].Value; 
                    string number = match.Groups[3].Value;

                    int newNumber = int.Parse(number) + 1;

                    string newNumberStr = newNumber.ToString().PadLeft(zeros.Length + number.Length, '0');

                    result = prefix + newNumberStr;
                }
                else if (data == null)
                {
                    return new NotFoundRecordResult<string>("Không thể lấy lớn nhất");
                }
                return new ExcuteResult<string>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<string>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ExcuteResult<TitleAddDto>> AddTitle(TitleAddDto dto)
        {
            try
            {

                var Title = _mapper.Map<Title>(dto);
                var result = await _contractRepository.AddEntityAsync(Title);
                if (!result)
                {
                    return new NotFoundRecordResult<TitleAddDto>("Không thể thêm phòng ban");
                }
                return new ExcuteResult<TitleAddDto>(dto, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<TitleAddDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ExcuteResult<bool?>> UpdateAsync(TitleUpdateDto model)
        {
            try
            {
                _contractRepository.BeginTransaction();
                var existEntity = await _contractRepository.GetAsync(c => c.TitleId == model.TitleId);
                var Title = _mapper.Map(model, existEntity);

                await _contractRepository.UpdateEntityAsync(Title, false);
                var updateResult = await _contractRepository.CommitTransactionAsync();
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

        [HttpDelete]
        [Route("delete")]
        public async Task<ExcuteResult<bool?>> DeleteTitle(string id)
        {
            try
            {
                var result = await _contractRepository.DeleteAsync(id);
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
