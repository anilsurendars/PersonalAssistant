namespace PersonalAssistant.Service.Interfaces;

public  interface IWebsiteService
{
    Task<WebsiteModel> Create(WebsiteModel websiteModel);
    Task<bool> Update(WebsiteModel websiteModel, int websiteId);
    Task<bool> Delete(int websiteId, int userId);

    Task<WebsiteModel> GetWebsite(int websiteId);
    Task<IList<WebsiteModel>> GetWebsites();

}
