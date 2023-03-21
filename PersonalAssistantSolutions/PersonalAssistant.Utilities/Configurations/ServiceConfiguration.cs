namespace PersonalAssistant.Utilities.Configurations;

public static class ServiceConfiguration
{
    public static void RegisterUtilityComponents(this IServiceCollection serviceCollection, ConfigOption configOption)
    {
        serviceCollection.AddSingleton<IClock, Clock>();
    }
}
