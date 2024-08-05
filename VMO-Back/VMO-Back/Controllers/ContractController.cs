using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Model;
using Model.Utils;
using Share;
using System.Text.RegularExpressions;
using VMO_Back.Repository.Implement;
using VMO_Back.Repository.Interface;
using static Service.IService.IContractService;
using static Service.IService.IContractTypeService;

namespace VMO_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        readonly ILogger<ContractController> _logger;
        readonly IContractRepository _contractRepository;
        readonly IMapper _mapper;

        public ContractController(ILogger<ContractController> logger,
            IMapper mapper,
            IContractRepository ContractRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _contractRepository = ContractRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ExcuteResult<ListContractResult>> GetAllAsync()
        {
            try
            {
                ContractSearch model = new ContractSearch
                {
                    Page = new Share.Domain.Page
                    {
                        PageIndex = 0,
                        PageSize = 15
                    },
                    StatusSign = StatusSign.All,
                    Status = ActiveStatus.All
                };
                var filter = model.CreateFilter(_contractRepository.GetQueryable());
                var data = await _contractRepository.ExecuteWithTransactionAsync(filter);
                var result = new ListContractResult
                {
                    Data = _mapper.Map<List<ContractDto>>(data),
                    Total = data.Count,
                };

                return new ExcuteResult<ListContractResult>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ListContractResult>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ExcuteResult<ContractAddDto>> AddContract(ContractAddDto dto)
        {
            try
            {
                var Contract = _mapper.Map<Contract>(dto);
                var result = await _contractRepository.AddEntityAsync(Contract);
                if (!result)
                {
                    return new NotFoundRecordResult<ContractAddDto>("Không có hợp đồng");
                }
                return new ExcuteResult<ContractAddDto>(dto, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ContractAddDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpGet]
        [Route("detail")]
        public async Task<ExcuteResult<ContractDto>> GetTitleByIdAsync(string id)
        {
            try
            {
                var result = await _contractRepository.GetAsync(c => c.ContractId == id);
                if (result == null)
                {
                    return new NotFoundRecordResult<ContractDto>("Không thể thêm phòng ban");
                }
                var contract = _mapper.Map<ContractDto>(result);
                return new ExcuteResult<ContractDto>(contract, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ContractDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpGet]
        [Route("contractCode-max")]
        public async Task<ExcuteResult<string>> GetContractCodeMaxAsync()
        {
            try
            {
                var data = await _contractRepository.GetContractCodeMax();
                Regex regex = new Regex(@"(HD)(0*)(\d+)");
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

        [HttpPut]
        [Route("update")]
        public async Task<ExcuteResult<bool?>> UpdateAsync(ContractUpdateDto model)
        {
            try
            {
                _contractRepository.BeginTransaction();
                var existEntity = await _contractRepository.GetAsync(c => c.ContractId == model.ContractId);
                var Title = _mapper.Map(model, existEntity);

                await _contractRepository.UpdateEntityAsync(Title, false);
                var updateResult = await _contractRepository.CommitTransactionAsync();
                if (!updateResult)
                {
                    return new NotFoundRecordResult<bool?>("Không thể cập nhật hợp đồng");
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
                    return new NotFoundRecordResult<bool?>("Không thể xóa hợp đồng");
                }
                return new ExcuteResult<bool?>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<bool?>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpGet]
        [Route("overview-inc-dec")]
        public async Task<ExcuteResult<OverviewIncDec>> GetOverViewEmployeeIncDecAsync()
        {
            try
            {
                ContractSearch model = new ContractSearch
                {
                    Page = new Share.Domain.Page
                    {
                        PageIndex = 0,
                        PageSize = 15
                    },
                    StatusSign = StatusSign.All,
                    Status = ActiveStatus.All
                };
                var filter = model.CreateFilter(_contractRepository.GetQueryable());
                var data = await _contractRepository.ExecuteWithTransactionAsync(filter);
                var result = new OverviewIncDec
                {
                    Active = data.Where(c => c.Status == ActiveStatus.Active).Count(),
                    NoActive = data.Where(c => c.Status == ActiveStatus.NoActive).Count(),
                };
                return new ExcuteResult<OverviewIncDec>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<OverviewIncDec>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }
    }
}
