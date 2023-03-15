namespace PersonalAssistant.Data.Entities;

public partial class ContactType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Contact> Contacts { get; } = new List<Contact>();
}
