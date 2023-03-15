namespace PersonalAssistant.Models.PresentationModels;

public class WebsiteModel
{
    public int Id { get; set; }

    public string WebsiteName { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }
}
