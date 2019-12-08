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

        public async Task InitializeAsync()
        {
            if (_client is {}) return;

            var token = Environment.GetEnvironmentVariable("HumanToken", EnvironmentVariableTarget.Machine);

            _client = new DiscordClient(new DiscordConfiguration
                {
                    Token = token,
                    TokenType = TokenType.User,
                });
        }

        public async Task RunAsync()
        {
            await _client.ConnectAsync();
            commands = _client.UseCommandsNext(new CommandsNextConfiguration
            {
                EnableDms = true,

            });

            commands.RegisterAllCommands();

            _client.MessageCreated += async e =>
            {
                // ronan's ID
                if (e.Message.Author.Id == 287208546016165888)
                    await e.Message.RespondAsync($"{e.Message.Author.Mention} is noob");
            };
            await Task.Delay(-1);
        }

        public async Task StopAsync()
        {
            throw new NotImplementedException();
        }
    }
}
