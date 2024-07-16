using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Model;
using Model.Utils;
using Share;
using VMO_Back.Repository.Implement;
using VMO_Back.Repository.Interface;
using static Service.IService.IBenefitService;
using static Service.IService.ITitleService;

namespace VMO_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitController : ControllerBase
    {
        readonly ILogger<BenefitController> _logger;
        readonly IBenefitRepository _BenefitRepository;
        readonly IMapper _mapper;

        public BenefitController(ILogger<BenefitController> logger,
            IMapper mapper,
            IBenefitRepository BenefitRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _BenefitRepository = BenefitRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ExcuteResult<ListBenefitResult>> GetAllBenefitAsync()
        {
            try
            {
                BenefitSearch model = new BenefitSearch
                {
                    Page = new Share.Domain.Page
                    {
                        PageIndex = 0,
                        PageSize = 15
                    },
                    Status = ActiveStatus.All
                };
                var filter = model.CreateFilter(_BenefitRepository.GetQueryable());
                var data = await _BenefitRepository.ExecuteWithTransactionAsync(filter);

                var result = new ListBenefitResult
                {
                    Data = _mapper.Map<List<BenefitDto>>(data),
                    Total = data.Count,
                };
                
                return new ExcuteResult<ListBenefitResult>(result, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<ListBenefitResult>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<ExcuteResult<BenefitAddDto>> AddBenefit(BenefitAddDto dto)
        {
            try
            {
                var benefit = _mapper.Map<Benefit>(dto);
                var result = await _BenefitRepository.AddEntityAsync(benefit);
                if (!result)
                {
                    return new NotFoundRecordResult<BenefitAddDto>("Không có hồ sơ lương");
                }
                return new ExcuteResult<BenefitAddDto>(dto, ResultCode.SuccessResult, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ExcuteResult<BenefitAddDto>(null) { Code = ResultCode.ExceptionResult, ErrorMessage = ex.Message };
            }
        }

    }
}
