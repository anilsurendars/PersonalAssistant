namespace PersonalAssistant.Data.UnitOfWorks;

public class AuthUnitOfWork : IAuthUnitOfWork
{
    private readonly PersonalAssistantDatabaseContext _context;
    private readonly UserManager<ApiUser> _userManager;
    private IDbContextTransaction _transaction;

    public AuthUnitOfWork(PersonalAssistantDatabaseContext context, UserManager<ApiUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public UserManager<ApiUser> UserManager => _userManager;

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _transaction?.CommitAsync(cancellationToken);
        _transaction.Dispose();
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _transaction?.RollbackAsync(cancellationToken);
        _transaction.Dispose();
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context?.Dispose();
            _transaction?.Dispose();
        }
    }
}
