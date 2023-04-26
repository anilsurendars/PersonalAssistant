namespace PersonalAssistant.Service.Services;

public class AuthService : IAuthService
{
    private readonly ILogger<AuthService> _logger;
    private readonly IAuthUnitOfWork _authUnitOfWork;
    private readonly IMapper _mapper;

    public AuthService(ILogger<AuthService> logger, IAuthUnitOfWork authUnitOfWork, IMapper mapper)
    {
        _logger = logger;
        _authUnitOfWork = authUnitOfWork;
        _mapper = mapper;
    }

    public async Task<IdentityResult> Create(UserModel user)
    {
        try
        {
            var apiUser = _mapper.Map<ApiUser>(user);
            apiUser.UserName = apiUser.Email;

            var result = await _authUnitOfWork.UserManager.CreateAsync(apiUser, user.Password);

            if (result.Succeeded)
            {
                await _authUnitOfWork.UserManager.AddToRoleAsync(apiUser, AppConstants.User);
            }

            return result;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Login(LoginModel loginModel)
    {
        try
        {
            var user = await _authUnitOfWork.UserManager.FindByEmailAsync(loginModel.Email);
            var isPasswordValid = await _authUnitOfWork.UserManager.CheckPasswordAsync(user, loginModel.Password);

            return user != null && isPasswordValid;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
