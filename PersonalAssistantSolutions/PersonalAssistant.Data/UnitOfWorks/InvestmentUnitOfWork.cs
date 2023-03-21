namespace PersonalAssistant.Data.UnitOfWorks;

public class InvestmentUnitOfWork : IInvestmentUnitOfWork
{
    private IDbContextTransaction _transaction;
    private readonly PersonalAssistantDatabaseContext _context;
    private readonly IWebsiteRepository _websiteRepo;
    private readonly IRepository<WebsiteAudit> _websiteAuditRepo;
    private readonly IRepository<Investment> _investmentRepo;
    private readonly IRepository<InvestmentAudit> _investmentAuditRepo;
    private readonly IRepository<IntervalType> _intervalTypeRepo;
    private readonly IRepository<InvestmentType> _investmentTypeRepo;

    public InvestmentUnitOfWork(PersonalAssistantDatabaseContext context, IWebsiteRepository websiteRepo,
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

    public IWebsiteRepository WebsiteRepo => _websiteRepo;
    public IRepository<Investment> InvestmentRepo => _investmentRepo;
    public IRepository<InvestmentType> InvestmentTypeRepo => _investmentTypeRepo;
    public IRepository<IntervalType> IntervalTypeRepo => _intervalTypeRepo;
    public IRepository<WebsiteAudit> WebsiteAuditRepo => _websiteAuditRepo;
    public IRepository<InvestmentAudit> InvestmentAudit => _investmentAuditRepo;

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
