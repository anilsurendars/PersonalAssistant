using Microsoft.Extensions.DependencyInjection;
using PersonalAssistant.Data;
using PersonalAssistant.Models;
using PersonalAssistant.Models.OptionModels;

namespace PersonalAssistant.Service
{
    public static class ServiceConfiguration
    {
        public static void RegisterServiceComponents(this IServiceCollection serviceCollection, ConfigOption configOption)
        {
            serviceCollection.RegisterDataComponents(configOption);
        }
    }
}
