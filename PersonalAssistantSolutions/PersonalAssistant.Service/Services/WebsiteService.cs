namespace PersonalAssistant.Service.Services;

public class WebsiteService : IWebsiteService
{
    private readonly ILogger<WebsiteService> _logger;
    private readonly IInvestmentUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WebsiteService(ILogger<WebsiteService> logger, IInvestmentUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<WebsiteModel> Create(WebsiteModel websiteModel)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(websiteModel, nameof(websiteModel));

            var isExist = _unitOfWork.WebsiteRepo.GetAllAsQuarable().Any(x=> x.WebsiteName == websiteModel.WebsiteName && x.Url == websiteModel.Url);
            if (isExist)
            {
                _logger.LogInformation($"Website already present. {nameof(websiteModel)}: {JsonConvert.SerializeObject(websiteModel)}");
                return null;
            }

            var entity = _mapper.Map<Website>(websiteModel);
            entity.IsActive = true;

            await _unitOfWork.BeginTransactionAsync();
            
            var auditEntity = _mapper.Map<WebsiteAudit>(entity);
            
            _unitOfWork.WebsiteRepo.Add(entity);
            _unitOfWork.WebsiteAuditRepo.Add(auditEntity);

            var result = await _unitOfWork.SaveAsync();

            await _unitOfWork.CommitTransactionAsync();

            if(result > 0)
            {
                return _mapper.Map<WebsiteModel>(entity);
            }
        }
        catch (Exception)
        {
            throw;
        }
        return null;
    }

    public async Task<bool> Delete(int websiteId)
    {
        try
        {
            if(websiteId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(websiteId));
            }

            var entity = await _unitOfWork.WebsiteRepo.Get(websiteId);
            if (entity != null)
            {
                _logger.LogInformation($"Website available, deleting the website. {nameof(websiteId)}: {websiteId}");
                entity.IsActive = false;

                await _unitOfWork.BeginTransactionAsync();

                var auditEntity = _mapper.Map<WebsiteAudit>(entity);

                _unitOfWork.WebsiteRepo.Add(entity);
                _unitOfWork.WebsiteAuditRepo.Add(auditEntity);

                var result = await _unitOfWork.SaveAsync();

                await _unitOfWork.CommitTransactionAsync();

                return true;
            }
            else
            {
                _logger.LogInformation($"Website not availabl. {nameof(websiteId)}: {websiteId}");
                return false;
            }
        }
        catch (Exception)
        {
            throw;
        }
        throw new NotImplementedException();
    }

    public Task<IList<WebsiteModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<WebsiteModel> GetWebsite(int websiteId)
    {
        throw new NotImplementedException();
    }

    public Task<WebsiteModel> Update(WebsiteModel websiteModel, int websiteId)
    {
        throw new NotImplementedException();
    }
}
