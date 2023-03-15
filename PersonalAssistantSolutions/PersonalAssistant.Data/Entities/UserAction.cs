namespace PersonalAssistant.Data.Entities;

public partial class UserAction
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ContactAudit> ContactAudits { get; } = new List<ContactAudit>();

    public virtual ICollection<WebsiteAudit> WebsiteAudits { get; } = new List<WebsiteAudit>();
}
