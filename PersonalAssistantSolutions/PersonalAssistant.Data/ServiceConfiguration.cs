namespace PersonalAssistant.Data;

public static class ServiceConfiguration
{
    public static void RegisterDataComponents(this IServiceCollection serviceCollection, ConfigOption configOption)
    {
        serviceCollection.AddDbContext<PersonalAssistantDatabaseContext>(options => options.UseSqlServer(configOption.ConnectionString));
        
        serviceCollection.RegisterRepositories();
        serviceCollection.RegisterUnitOfWorks();
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }

    private static void RegisterUnitOfWorks(this IServiceCollection services)
    {
        services.AddScoped<IContactUnitOfWork, ContactUnitOfWork>();
        services.AddScoped<IInvestmentUnitOfWork, InvestmentUnitOfWork>();
        services.AddScoped<ILookupUnitOfWork, LookupUnitOfWork>();
    }
}
