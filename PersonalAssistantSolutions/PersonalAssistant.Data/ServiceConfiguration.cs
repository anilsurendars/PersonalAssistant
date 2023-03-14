using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalAssistant.Data.Context;
using PersonalAssistant.Models.OptionModels;

namespace PersonalAssistant.Data
{
    public static class ServiceConfiguration
    {
        public static void RegisterDataComponents(this IServiceCollection serviceCollection, ConfigOption configOption)
        {
            serviceCollection.AddDbContext<PersonalAssistantDatabaseContext>(options => options.UseSqlServer(configOption.ConnectionString));
        }
    }
}
