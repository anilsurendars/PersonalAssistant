namespace PersonalAssistant.Data.UnitOfWorks;

public class ContactUnitOfWork : IContactUnitOfWork
{
    private readonly PersonalAssistantDatabaseContext _context;
    private readonly IRepository<Contact> _contactRepo;
    private readonly IRepository<ContactType> _contactTypeRepo;
    private readonly IRepository<ContactAudit> _contactAuditRepo;
    private IDbContextTransaction _transaction;

    public ContactUnitOfWork(PersonalAssistantDatabaseContext context, IRepository<Contact> contactRepo,
        IRepository<ContactType> contactTypeRepo, IRepository<ContactAudit> contactAuditRepo)
    {
        _context = context;
        _contactRepo = contactRepo;
        _contactTypeRepo = contactTypeRepo;
        _contactAuditRepo = contactAuditRepo;
    }

    public IRepository<Contact> ContactRepo => _contactRepo;
    public IRepository<ContactAudit> ContactAuditRepo => _contactAuditRepo;
    public IRepository<ContactType> ContactTypeRepo => _contactTypeRepo;

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
