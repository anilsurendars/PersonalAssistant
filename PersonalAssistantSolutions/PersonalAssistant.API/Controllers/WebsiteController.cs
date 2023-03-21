using PersonalAssistant.Models.PresentationModels;
using PersonalAssistant.Utilities.Helpers;

namespace PersonalAssistant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebsiteController : ControllerBase
{
    private readonly ILogger<WebsiteController> _logger;
    private readonly IWebsiteService _service;

    public WebsiteController(ILogger<WebsiteController> logger, IWebsiteService service)
    {
        _logger = logger;
        _service = service;
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

        var result = await _service.Create(model);

        return CreatedAtAction("GetWebsite", new { id = result.Id }, result);
    }
}
