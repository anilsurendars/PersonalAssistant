using System;
using System.Collections.Generic;

namespace PersonalAssistant.Data.Entities;

public partial class WebsiteAudit
{
    public long Id { get; set; }

    public DateTime LogDateTime { get; set; }

    public int ActionId { get; set; }

    public int ActionUserId { get; set; }

    public int WebsiteId { get; set; }

    public string WebsiteName { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual UserAction Action { get; set; } = null!;
}
