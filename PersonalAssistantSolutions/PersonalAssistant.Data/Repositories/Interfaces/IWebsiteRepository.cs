namespace PersonalAssistant.Data.Repositories.Interfaces;

public interface IWebsiteRepository : IRepository<Website>
{
    Task<Website> GetWebsite(string name, string url);
}
