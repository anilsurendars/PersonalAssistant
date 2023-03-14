using System;
using System.Collections.Generic;

namespace PersonalAssistant.Data.Entities;

public partial class InvestmentAudit
{
    public long Id { get; set; }

    public DateTime LogDateTime { get; set; }

    public int ActionId { get; set; }

    public int ActionUserId { get; set; }

    public int InvestmentId { get; set; }

    public int InvestementTypeId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Amount { get; set; }

    public int IntervalTypeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime DueDate { get; set; }

    public string PaymentMode { get; set; } = null!;

    public int? WebsiteId { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }
}
