using Microsoft.AspNetCore.Identity;

namespace PersonalAssistant.Data.Entities;

public class ApiUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
