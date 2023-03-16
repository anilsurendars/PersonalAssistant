namespace PersonalAssistant.Data.UnitOfWorks;

public class InvestmentUnitOfWork : IInvestmentUnitOfWork
{
    private IDbContextTransaction _transaction;
    private readonly PersonalAssistantDatabaseContext _context;
    private readonly IRepository<Website> _websiteRepo;
    private readonly IRepository<WebsiteAudit> _websiteAuditRepo;
    private readonly IRepository<Investment> _investmentRepo;
    private readonly IRepository<InvestmentAudit> _investmentAuditRepo;
    private readonly IRepository<IntervalType> _intervalTypeRepo;
    private readonly IRepository<InvestmentType> _investmentTypeRepo;

    public InvestmentUnitOfWork(PersonalAssistantDatabaseContext context, IRepository<Website> websiteRepo, 
        IRepository<WebsiteAudit> websiteAuditRepo, IRepository<Investment> investmentRepo, 
        IRepository<InvestmentAudit> investmentAuditRepo, IRepository<IntervalType> intervalTypeRepo, 
        IRepository<InvestmentType> investmentTypeRepo)
    {
        _context = context;
        _websiteRepo = websiteRepo;
        _websiteAuditRepo = websiteAuditRepo;
        _investmentRepo = investmentRepo;
        _investmentAuditRepo = investmentAuditRepo;
        _intervalTypeRepo = intervalTypeRepo;
        _investmentTypeRepo = investmentTypeRepo;
    }

    public IRepository<Website> WebsiteRepo => _websiteRepo;
    public IRepository<Investment> InvestmentRepo => _investmentRepo;
    public IRepository<InvestmentType> InvestmentTypeRepo => _investmentTypeRepo;
    public IRepository<IntervalType> IntervalTypeRepo => _intervalTypeRepo;
    public IRepository<WebsiteAudit> WebsiteAuditRepo => _websiteAuditRepo;
    public IRepository<InvestmentAudit> InvestmentAudit => _investmentAuditRepo;

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
