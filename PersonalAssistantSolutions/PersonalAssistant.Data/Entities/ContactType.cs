namespace PersonalAssistant.Data.Entities;

public partial class ContactType
{
    public int Id { get; set; }

    public string ContactType1 { get; set; } = null!;

    public virtual ICollection<Contact> Contacts { get; } = new List<Contact>();
}
