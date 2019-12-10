using System;
using TheHuman.Core;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using TheHuman.Discord.Extensions;

namespace TheHuman.Discord
{
    public class DSharpHumanClient : IHumanClient
    {
        private DiscordClient _client;
        private CommandsNextModule commands;

        private Task InitializeAsync()
        {
            if (_client is {}) return Task.CompletedTask;

            var token = Environment.GetEnvironmentVariable("HumanToken", EnvironmentVariableTarget.Machine);

            _client = new DiscordClient(new DiscordConfiguration
                {
                    Token = token,
                    TokenType = TokenType.User,
                });

            return Task.CompletedTask;
        }

        public async Task RunAsync()
        {
            if (_client is null) await InitializeAsync();

            _client.MessageCreated += async e =>
            {
            };

            commands = _client.UseCommandsNext(new CommandsNextConfiguration
            {
                EnableDms = true,
                CaseSensitive = false,
                EnableDefaultHelp = true,
                EnableMentionPrefix = true,
                IgnoreExtraArguments = false,
                StringPrefix = "!",

            });

            commands.RegisterAllCommands();

            await _client.ConnectAsync();
            await Task.Delay(-1);
        }

        public async Task StopAsync()
        {
            await _client.DisconnectAsync();
            Environment.Exit(0);
        }
    }
}
