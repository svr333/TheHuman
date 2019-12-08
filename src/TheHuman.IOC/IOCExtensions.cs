using Microsoft.Extensions.DependencyInjection;
using TheHuman.Core;
using TheHuman.Discord;

namespace TheHuman.IOC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBotServices(this IServiceCollection services)
        => services.AddSingleton<IHumanClient, DSharpHumanClient>();
    }
}
