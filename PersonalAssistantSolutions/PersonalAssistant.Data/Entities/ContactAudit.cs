using System;
using System.Collections.Generic;

namespace PersonalAssistant.Data.Entities;

public partial class ContactAudit
{
    public long Id { get; set; }

    public DateTime LogDateTime { get; set; }

    public int ActionId { get; set; }

    public int ActionUserId { get; set; }

    public int ContactId { get; set; }

    public int ContactTypeId { get; set; }

    public string MemberName { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string? PersonalContactNumber { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual UserAction Action { get; set; } = null!;
}
