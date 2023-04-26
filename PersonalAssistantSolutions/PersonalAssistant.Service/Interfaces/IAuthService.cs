namespace PersonalAssistant.Service.Interfaces;

public interface IAuthService
{
    Task<IdentityResult> Create(UserModel user);
    Task<bool> Login(LoginModel login);
}