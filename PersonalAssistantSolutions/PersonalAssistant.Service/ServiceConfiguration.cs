namespace PersonalAssistant.Service;

public static class ServiceConfiguration
{
    public static void RegisterServiceComponents(this IServiceCollection serviceCollection, ConfigOption configOption)
    {
        serviceCollection.RegisterDataComponents(configOption);
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IInvestmentService, InvestmentService>();
        services.AddScoped<IContactService, ContactService>();
    }
}
