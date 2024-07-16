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
                    return new NotFoundRecordResult<List<ContractDto>>("Không có nhân viên");
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
                    return new NotFoundRecordResult<ContractAddDto>("Không có nhân viên");
                }
                return new ExcuteResult<ContractAddDto>(dto, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ContractAddDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }
    }
}
