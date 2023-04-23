namespace PersonalAssistant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LookupController : ControllerBase
{
    private readonly ILogger<LookupController> _logger;
    private readonly ILookupService _service;

    public LookupController(ILogger<LookupController> logger, ILookupService service)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [Route("GetIntervalTypes")]
    public async Task<IActionResult> GetIntervalTypes()
    {
        return Ok((await _service.GetIntervalTypes()).GetResponse());
    }

    [HttpGet]
    [Route("GetContactTypes")]
    public async Task<IActionResult> GetContactTypes()
    {
        return Ok((await _service.GetContactTypes()).GetResponse());
    }

    [HttpGet]
    [Route("GetInvestmentTypes")]
    public async Task<IActionResult> GetInvestmentTypes()
    {
        return Ok((await _service.GetInvestmentTypes()).GetResponse());
    }
}
