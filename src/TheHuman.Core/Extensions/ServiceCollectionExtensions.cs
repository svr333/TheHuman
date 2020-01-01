using Microsoft.Extensions.DependencyInjection;

namespace TheHuman.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBotServices(this IServiceCollection services)
        => services.AddSingleton<>();
    }
}
