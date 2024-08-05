using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Model;
using Share;
using static Service.IService.IContractTypeService;
using VMO_Back.Repository.Interface;
using Model.Utils;
using System.Diagnostics.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VMO_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractTypeController : ControllerBase
    {
        readonly ILogger<ContractTypeController> _logger;
        readonly IContractTypeRepository _conractTypeRepository;
        readonly IMapper _mapper;

        public ContractTypeController(ILogger<ContractTypeController> logger,
            IMapper mapper,
            IContractTypeRepository ContractTypeRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _conractTypeRepository = ContractTypeRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ExcuteResult<ListContractTypeResult>> GetAllContractTypeAsync()
        {
            try
            {
                ContractTypeSearch model = new ContractTypeSearch
                {
                    Page = new Share.Domain.Page
                    {
                        PageIndex = 0,
                        PageSize = 15
                    },
                    Status = ActiveStatus.All
                };
                var filter = model.CreateFilter(_conractTypeRepository.GetQueryable());
                var data = await _conractTypeRepository.ExecuteWithTransactionAsync(filter);
                var result = new ListContractTypeResult
                {
                    Data = _mapper.Map<List<ContractTypeDto>>(data),
                    Total = 0,
                };
                return new ExcuteResult<ListContractTypeResult>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ListContractTypeResult>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpGet]
        [Route("detail")]
        public async Task<ExcuteResult<ContractTypeDto>> GetContractTypeByIdAsync(string id)
        {
            try
            {
                var result = await _conractTypeRepository.GetAsync(c => c.ContractTypeId == id);
                if (result == null)
                {
                    return new NotFoundRecordResult<ContractTypeDto>("Không thể thêm phòng ban");
                }
                var ContractType = _mapper.Map<ContractTypeDto>(result);
                return new ExcuteResult<ContractTypeDto>(ContractType, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ContractTypeDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ExcuteResult<ContractTypeAddDto>> AddContractType(ContractTypeAddDto dto)
        {
            try
            {
                var ContractType = _mapper.Map<ContractType>(dto);
                var result = await _conractTypeRepository.AddEntityAsync(ContractType);
                if (!result)
                {
                    return new NotFoundRecordResult<ContractTypeAddDto>("Không thể thêm phòng ban");
                }
                return new ExcuteResult<ContractTypeAddDto>(dto, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ContractTypeAddDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<ExcuteResult<bool?>> UpdateAsync(ContractTypeUpdateDto model)
        {
            try
            {
                var existEntity = await _conractTypeRepository.GetAsync(c => c.ContractTypeId == model.ContractTypeId);
                var ContractType = _mapper.Map(model, existEntity);

                await _conractTypeRepository.UpdateEntityAsync(ContractType, false);
                var updateResult = await _conractTypeRepository.CommitTransactionAsync();
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
        public async Task<ExcuteResult<bool?>> DeleteContractType(string id)
        {
            try
            {
                var result = await _conractTypeRepository.DeleteAsync(id);
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

        [HttpGet]
        [Route("overview")]
        public async Task<ExcuteResult<ListContractTypeOverviewResult>> GetOverViewEmployeeAsync()
        {
            try
            {
                var result = await _conractTypeRepository.GetOverViewEmployeeAsync();
                var resultData = new ListContractTypeOverviewResult
                {
                    Data = result,
                    Total = result.Count,
                };
                return new ExcuteResult<ListContractTypeOverviewResult>(resultData, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ListContractTypeOverviewResult>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

    }
}
