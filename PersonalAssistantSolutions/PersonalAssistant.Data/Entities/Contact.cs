using System;
using System.Collections.Generic;

namespace PersonalAssistant.Data.Entities;

public partial class Contact
{
    public int Id { get; set; }

    public int ContactTypeId { get; set; }

    public string MemberName { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string? PersonalContactNumber { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ContactType ContactType { get; set; } = null!;
}
