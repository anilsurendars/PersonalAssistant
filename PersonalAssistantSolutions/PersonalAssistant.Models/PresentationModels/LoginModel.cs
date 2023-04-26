namespace PersonalAssistant.Models.PresentationModels;

public class LoginModel
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}
