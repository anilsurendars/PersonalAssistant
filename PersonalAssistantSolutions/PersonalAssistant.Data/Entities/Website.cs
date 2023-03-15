namespace PersonalAssistant.Data.Entities;

public partial class Website
{
    public int Id { get; set; }

    public string WebsiteName { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<Investment> Investments { get; } = new List<Investment>();
}
