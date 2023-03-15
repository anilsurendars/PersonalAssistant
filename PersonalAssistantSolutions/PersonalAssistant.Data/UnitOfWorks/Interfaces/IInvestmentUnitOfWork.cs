using PersonalAssistant.Data.Entities;
using PersonalAssistant.Data.Repositories.Interfaces;

namespace PersonalAssistant.Data.UnitOfWorks.Interfaces
{
    public interface IInvestmentUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        Task<int> SaveAsync(CancellationToken cancellationToken = default);

        IRepository<Website> WebsiteRepo { get; }
        IRepository<Investment> InvestmentRepo { get; }
        IRepository<InvestmentType> InvestmentTypeRepo { get; }
        IRepository<IntervalType> IntervalTypeRepo { get; }
        IRepository<WebsiteAudit> WebsiteAuditRepo { get; }
        IRepository<InvestmentAudit> InvestmentAudit { get; }
    }
}
