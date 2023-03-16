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
        try
        {
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _transaction?.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _transaction?.RollbackAsync(cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Dispose()
    {
        try
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        try
        {
            if (disposing)
            {
                _context?.Dispose();
                _transaction?.Dispose();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
