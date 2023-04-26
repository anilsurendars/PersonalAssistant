namespace PersonalAssistant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IMapper mapper, IAuthService authService)
    {
        _logger = logger;
        _mapper = mapper;
        _authService = authService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> Register(UserModel userModel)
    {
        var result = await _authService.Create(userModel);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        return Accepted(result);
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login(LoginModel loginModel)
    {
        var isValid = await _authService.Login(loginModel);

        return isValid ? Accepted() : NotFound();
    }
}
