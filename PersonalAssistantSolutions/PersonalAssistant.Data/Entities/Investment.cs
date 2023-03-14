using System;
using System.Collections.Generic;

namespace PersonalAssistant.Data.Entities;

public partial class Investment
{
    public int Id { get; set; }

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

    public virtual IntervalType IntervalType { get; set; } = null!;

    public virtual InvestmentType InvestementType { get; set; } = null!;

    public virtual Website? Website { get; set; }
}
