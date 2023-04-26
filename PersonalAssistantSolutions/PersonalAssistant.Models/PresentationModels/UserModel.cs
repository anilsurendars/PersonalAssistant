namespace PersonalAssistant.Models.PresentationModels;

public class UserModel : LoginModel
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Role { get; set; }
}
