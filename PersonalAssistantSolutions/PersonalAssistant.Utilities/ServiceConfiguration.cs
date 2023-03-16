namespace PersonalAssistant.Utilities;

public static class ServiceConfiguration
{
    public static void RegisterUtilityComponents(this IServiceCollection serviceCollection, ConfigOption configOption)
    {
        serviceCollection.AddSingleton<IClock, Clock>();
    }
}
