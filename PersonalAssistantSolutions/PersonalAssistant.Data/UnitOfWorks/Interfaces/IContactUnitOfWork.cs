using PersonalAssistant.Data.Entities;
using PersonalAssistant.Data.Repositories.Interfaces;

namespace PersonalAssistant.Data.UnitOfWorks.Interfaces
{
    public interface IContactUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        Task<int> SaveAsync(CancellationToken cancellationToken = default);

        IRepository<Contact> ContactRepo { get; }
        IRepository<ContactAudit> ContactAuditRepo { get; }
        IRepository<ContactType> ContactTypeRepo { get; }
    }
}
