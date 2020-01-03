using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TheHuman.Commands;

namespace TheHuman
{
    public class HumanClient
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        public HumanClient(DiscordSocketClient client = null, CommandService commands = null)
        {
            _client = client ?? new DiscordSocketClient(new DiscordSocketConfig()
            {
                AlwaysDownloadUsers = true,
                DefaultRetryMode = RetryMode.RetryRatelimit,
                MessageCacheSize = 250,
                LogLevel = LogSeverity.Verbose
            });

            _commands = commands ?? new CommandService(new CommandServiceConfig()
            {
                CaseSensitiveCommands = false,
                LogLevel = LogSeverity.Verbose,
                SeparatorChar = '|',
                DefaultRunMode = RunMode.Sync,
                ThrowOnError = true
            });
        }

        public async Task InitializeAsync()
        {
            _services = ConfigureServices();

            await _client.LoginAsync(TokenType.User, Environment.GetEnvironmentVariable("HumanToken"));
            await _client.StartAsync();

            await _services.GetRequiredService<CommandHandler>().InitializeAsync();

            await Task.Delay(-1);
        }

        public IServiceProvider ConfigureServices(IServiceCollection collection = null)
        {
            var p = collection ?? new ServiceCollection();

            p.AddSingleton(_client);
            p.AddSingleton(_commands);
            p.AddSingleton<CommandHandler>();
            p.AddSingleton<LavaConfig>();
            p.AddSingleton<LavaNode>();

            return p.BuildServiceProvider();
        }
    }
}
