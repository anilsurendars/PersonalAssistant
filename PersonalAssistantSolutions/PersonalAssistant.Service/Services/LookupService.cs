namespace PersonalAssistant.Service.Services;

public class LookupService : ILookupService
{
    private readonly ILogger<LookupService> _logger;
    private readonly ILookupUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LookupService(ILogger<LookupService> logger, ILookupUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IList<ContactTypeModel>> GetContactTypes()
    {
        try
        {
            var entities = await _unitOfWork.ContactTypeRepo.GetAllAsync();

            return _mapper.Map<IList<ContactTypeModel>>(entities);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IList<IntervalTypeModel>> GetIntervalTypes()
    {
        try
        {
            var entities = await _unitOfWork.IntervalTypeRepo.GetAllAsync();

            return _mapper.Map<IList<IntervalTypeModel>>(entities);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IList<InvestmentTypeModel>> GetInvestmentTypes()
    {
        try
        {
            var entities = await _unitOfWork.InvestmentTypeRepo.GetAllAsync();

            return _mapper.Map<IList<InvestmentTypeModel>>(entities);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
