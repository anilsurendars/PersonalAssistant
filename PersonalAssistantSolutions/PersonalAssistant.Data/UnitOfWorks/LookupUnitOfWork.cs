namespace PersonalAssistant.Data.UnitOfWorks;

public class LookupUnitOfWork : ILookupUnitOfWork
{
    private IDbContextTransaction _transaction;
    private readonly PersonalAssistantDatabaseContext _context;

    private readonly IRepository<IntervalType> _intervalTypeRepo;
    private readonly IRepository<InvestmentType> _investmentTypeRepo;
    private readonly IRepository<ContactType> _contactTypeRepo;

    public LookupUnitOfWork(IRepository<IntervalType> intervalTypeRepo, IRepository<InvestmentType> investmentTypeRepo,
        IRepository<ContactType> contactTypeRepo, PersonalAssistantDatabaseContext context)
    {
        _intervalTypeRepo = intervalTypeRepo;
        _investmentTypeRepo = investmentTypeRepo;
        _contactTypeRepo = contactTypeRepo;
        _context = context;
    }

    public IRepository<ContactType> ContactTypeRepo => _contactTypeRepo;
    public IRepository<InvestmentType> InvestmentTypeRepo => _investmentTypeRepo;
    public IRepository<IntervalType> IntervalTypeRepo => _intervalTypeRepo;

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _transaction?.CommitAsync(cancellationToken);
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        await _transaction?.RollbackAsync(cancellationToken);
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
