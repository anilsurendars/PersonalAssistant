namespace PersonalAssistant.Models.PresentationModels;

public class ContactModel
{
    public int Id { get; set; }

    public int ContactTypeId { get; set; }

    public string MemberName { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string? PersonalContactNumber { get; set; }

    public bool IsActive { get; set; }

    public int ActionUserId { get; set; }
}
