namespace PersonalAssistant.Data.Entities;

public partial class IntervalType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Investment> Investments { get; } = new List<Investment>();
}
