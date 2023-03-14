namespace PersonalAssistant.Data.UnitOfWorks.Interfaces
{
    public interface IInvestmentUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
