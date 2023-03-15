namespace PersonalAssistant.Models.PresentationModels;

public class InvestmentModel
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
    public int ActionUserId { get; set; }
}
