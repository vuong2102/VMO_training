using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Model;
using Share;
using static Service.IService.IAllowanceService;
using VMO_Back.Repository.Interface;

namespace VMO_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllowanceController : ControllerBase
    {
        readonly ILogger<AllowanceController> _logger;
        readonly IAllowanceRepository _AllowanceRepository;
        readonly IMapper _mapper;

        public AllowanceController(ILogger<AllowanceController> logger,
            IMapper mapper,
            IAllowanceRepository AllowanceRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _AllowanceRepository = AllowanceRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ExcuteResult<ListAllowanceResult>> GetAllAllowanceAsync()
        {
            try
            {
                AllowanceSearch model = new AllowanceSearch
                {
                    Page = new Share.Domain.Page
                    {
                        PageIndex = 0,
                        PageSize = 15
                    },
                    Status = Model.Utils.ActiveStatus.All
                };
                var filter = model.CreateFilter(_AllowanceRepository.GetQueryable());
                var data = await _AllowanceRepository.ExecuteWithTransactionAsync(filter);

                var result = new ListAllowanceResult
                {
                    Data = _mapper.Map<List<AllowanceDto>>(data),
                    Total = data.Count,
                };

                return new ExcuteResult<ListAllowanceResult>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ListAllowanceResult>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ExcuteResult<AllowanceAddDto>> AddAllowance(AllowanceAddDto dto)
        {
            try
            {
                var allowance = _mapper.Map<Allowance>(dto);
                var result = await _AllowanceRepository.AddEntityAsync(allowance);
                if (!result)
                {
                    return new NotFoundRecordResult<AllowanceAddDto>("Không có hồ sơ lương");
                }
                return new ExcuteResult<AllowanceAddDto>(dto, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<AllowanceAddDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }
    }
}
