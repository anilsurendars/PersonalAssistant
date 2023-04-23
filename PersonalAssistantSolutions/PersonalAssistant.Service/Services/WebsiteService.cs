using PersonalAssistant.Utilities.Enums;
using PersonalAssistant.Utilities.Extensions;

namespace PersonalAssistant.Service.Services;

public class WebsiteService : IWebsiteService
{
    private readonly ILogger<WebsiteService> _logger;
    private readonly IInvestmentUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WebsiteService(ILogger<WebsiteService> logger, IInvestmentUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<WebsiteModel> Create(WebsiteModel websiteModel)
    {
        try
        {
            if (websiteModel == null)
            {
                throw new ArgumentNullException(nameof(websiteModel));
            }
            var existingWebsite = await _unitOfWork.WebsiteRepo.GetWebsite(websiteModel.WebsiteName, websiteModel.Url);

            if (existingWebsite != null)
            {
                _logger.LogInformation($"Website already present. {nameof(websiteModel)}: {JsonConvert.SerializeObject(websiteModel)}");
                return null;
            }

            var entity = _mapper.Map<Website>(websiteModel);
            entity.IsActive = true;

            var auditEntity = _mapper.Map<WebsiteAudit>(entity);
            auditEntity.ActionId = UserActionType.Create.ToInt();

            await _unitOfWork.BeginTransactionAsync();

            await _unitOfWork.WebsiteRepo.AddAsync(entity);
            await _unitOfWork.WebsiteAuditRepo.AddAsync(auditEntity);

            var result = await _unitOfWork.SaveAsync();

            await _unitOfWork.CommitTransactionAsync();

            return result > 0 ? _mapper.Map<WebsiteModel>(entity) : null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Delete(int websiteId, int userId)
    {
        try
        {
            if (websiteId <= 0 || userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(websiteId));
            }

            var entity = await _unitOfWork.WebsiteRepo.GetByIdAsync(websiteId);

            if (entity != null)
            {
                _logger.LogInformation($"Website available, deleting the website. {nameof(websiteId)}: {websiteId}");
                entity.IsActive = false;

                await _unitOfWork.BeginTransactionAsync();

                await _unitOfWork.WebsiteRepo.AddAsync(entity);
                await _unitOfWork.WebsiteAuditRepo.AddAsync(_mapper.Map<WebsiteAudit>(entity));

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
    }

    public async Task<IList<WebsiteModel>> GetWebsites()
    {
        try
        {
            var websites = await _unitOfWork.WebsiteRepo.GetAllAsync();

            return _mapper.Map<IList<WebsiteModel>>(websites);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<WebsiteModel> GetWebsite(int websiteId)
    {
        try
        {
            var website = await _unitOfWork.WebsiteRepo.GetByIdAsync(websiteId);

            return _mapper.Map<WebsiteModel>(website);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Update(WebsiteModel websiteModel, int websiteId)
    {
        try
        {
            if (websiteModel == null || websiteId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(websiteModel));
            }

            var entity = _mapper.Map<Website>(websiteModel);

            if (entity != null)
            {
                await _unitOfWork.BeginTransactionAsync();

                _unitOfWork.WebsiteRepo.Update(entity);
                await _unitOfWork.WebsiteAuditRepo.AddAsync(_mapper.Map<WebsiteAudit>(entity));

                var result = await _unitOfWork.SaveAsync();

                await _unitOfWork.CommitTransactionAsync();

                return true;
            }
            else
            {
                _logger.LogInformation($"Website not available. {nameof(websiteId)}: {websiteId}");
                return false;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
