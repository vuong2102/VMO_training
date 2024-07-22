using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Model;
using Share;
using VMO_Back.Repository.Implement;
using VMO_Back.Repository.Interface;

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
        public async Task<ExcuteResult<List<ContractDto>>> GetAllAsync()
        {
            try
            {
                var Contracts = await _contractRepository.GetAllWithFilterAsync();
                List<ContractDto> ContractsDto = _mapper.Map<List<ContractDto>>(Contracts);

                if (ContractsDto == null)
                {
                    return new NotFoundRecordResult<List<ContractDto>>("Không có hợp đồng");
                }
                return new ExcuteResult<List<ContractDto>>(ContractsDto, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<List<ContractDto>>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
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
    }
}
