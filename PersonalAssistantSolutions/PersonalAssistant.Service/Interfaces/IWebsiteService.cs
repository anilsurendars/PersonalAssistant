namespace PersonalAssistant.Service.Interfaces;

public  interface IWebsiteService
{
    Task<WebsiteModel> Create(WebsiteModel websiteModel);
    Task<WebsiteModel> Update(WebsiteModel websiteModel, int websiteId);
    Task<bool> Delete(int websiteId);

    Task<WebsiteModel> GetWebsite(int websiteId);
    Task<IList<WebsiteModel>> GetAll();

}
