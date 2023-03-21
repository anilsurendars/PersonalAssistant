using PersonalAssistant.Data.Configurations;

namespace PersonalAssistant.Service.Configurations;

public static class ServiceConfiguration
{
    public static void RegisterServiceComponents(this IServiceCollection serviceCollection, ConfigOption configOption)
    {
        serviceCollection.RegisterDataComponents(configOption);
        serviceCollection.RegisterServices();
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IInvestmentService, InvestmentService>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<ILookupService, LookupService>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<IWebsiteService, WebsiteService>();
    }
}
