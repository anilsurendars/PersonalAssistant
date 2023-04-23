
namespace PersonalAssistant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebsiteController : ControllerBase
{
    private readonly ILogger<WebsiteController> _logger;
    private readonly IWebsiteService _service;
    private readonly IValidator<WebsiteModel> _validator;

    public WebsiteController(ILogger<WebsiteController> logger, IWebsiteService service, IValidator<WebsiteModel> validator)
    {
        _logger = logger;
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetWebsites()
    {
        return Ok((await _service.GetWebsites()).GetResponse());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWebsite(int id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        return Ok((await _service.GetWebsite(id)).GetResponse());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutWebsite(int id, WebsiteModel model)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));
        ArgumentNullException.ThrowIfNull(model, nameof(model));

        if (id != model.Id)
        {
            return BadRequest();
        }

        var result = await _service.Update(model, id);

        return result ? NoContent() : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> PostWebsite(WebsiteModel model)
    {
        ArgumentNullException.ThrowIfNull(() => model, nameof(model));

        var validationResult = await _validator.ValidateAsync(model);

        if (!validationResult.IsValid)
        {
            return BadRequest(ResponseHelper.GetFailedResponse<WebsiteModel>(string.Join(",", validationResult.Errors)));
        }

        var result = await _service.Create(model);

        return CreatedAtAction("GetWebsite", new { id = result.Id }, result);
    }
}
