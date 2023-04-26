using Microsoft.AspNetCore.Identity;

namespace PersonalAssistant.Data.UnitOfWorks.Interfaces;

public interface IAuthUnitOfWork : IDisposable
{
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    Task<int> SaveAsync(CancellationToken cancellationToken = default);

    UserManager<ApiUser> UserManager { get; }
}
