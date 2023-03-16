namespace PersonalAssistant.Data.UnitOfWorks.Interfaces;

public interface ILookupUnitOfWork : IDisposable
{
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    Task<int> SaveAsync(CancellationToken cancellationToken = default);

    IRepository<ContactType> ContactTypeRepo { get; }
    IRepository<InvestmentType> InvestmentTypeRepo { get; }
    IRepository<IntervalType> IntervalTypeRepo { get; }
}
