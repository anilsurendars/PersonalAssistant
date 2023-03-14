using System;
using System.Collections.Generic;

namespace PersonalAssistant.Data.Entities;

public partial class InvestmentType
{
    public int Id { get; set; }

    public string InvestmentType1 { get; set; } = null!;

    public virtual ICollection<Investment> Investments { get; } = new List<Investment>();
}
