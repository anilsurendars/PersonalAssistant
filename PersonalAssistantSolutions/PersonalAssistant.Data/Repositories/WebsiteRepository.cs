namespace PersonalAssistant.Data.Repositories;

public class WebsiteRepository : Repository<Website>, IWebsiteRepository
{
    public WebsiteRepository(PersonalAssistantDatabaseContext context) : base(context)
    {
    }

    public Task<Website> GetWebsite(string name, string url)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(url))
        {
            throw new ArgumentException($"{nameof(name)} {nameof(url)}");
        }

        return _context.Websites.SingleOrDefaultAsync(x => x.WebsiteName == name && x.Url == url);
    }
}
