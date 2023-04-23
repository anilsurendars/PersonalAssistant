namespace PersonalAssistant.Models.Configurations;

public static class ServiceConfiguration
{
    public static void RegisterModelComponents(this IServiceCollection serviceCollection, ConfigOption configOption)
    {
        serviceCollection.RegisterValidators();
    }

    private static void RegisterValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<WebsiteModel>, WebsiteModelValidator>();
        services.AddValidatorsFromAssemblyContaining<WebsiteModelValidator>();
    }
}
