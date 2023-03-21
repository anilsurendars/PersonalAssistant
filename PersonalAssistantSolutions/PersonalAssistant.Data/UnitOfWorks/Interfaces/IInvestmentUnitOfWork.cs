namespace PersonalAssistant.Data.UnitOfWorks.Interfaces;

public interface IInvestmentUnitOfWork : IDisposable
{
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    Task<int> SaveAsync(CancellationToken cancellationToken = default);

    IWebsiteRepository WebsiteRepo { get; }
    IRepository<Investment> InvestmentRepo { get; }
    IRepository<InvestmentType> InvestmentTypeRepo { get; }
    IRepository<IntervalType> IntervalTypeRepo { get; }
    IRepository<WebsiteAudit> WebsiteAuditRepo { get; }
    IRepository<InvestmentAudit> InvestmentAudit { get; }
}
