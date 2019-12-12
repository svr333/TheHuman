using System;
using TheHuman.Core;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using TheHuman.Discord.Extensions;
using DSharpPlus.EventArgs;
using DSharpPlus.VoiceNext;
using DSharpPlus.VoiceNext.Codec;

namespace TheHuman.Discord
{
    public class DSharpHumanClient : IHumanClient
    {
        private DiscordClient _client;
        private CommandsNextModule commands;
        private VoiceNextClient _voice;

        private Task InitializeAsync()
        {
            if (_client != null) return Task.CompletedTask;

            var token = Environment.GetEnvironmentVariable("HumanToken", EnvironmentVariableTarget.Machine);

            _client = new DiscordClient(new DiscordConfiguration
                {
                    Token = token,
                    TokenType = TokenType.User,
                });

            _client.UnknownEvent += FriendAdded;

            return Task.CompletedTask;
        }

        private async Task FriendAdded(UnknownEventArgs eventArgs)
        {
            if (eventArgs.EventName != "RELATIONSHIP_ADD") return;

            var user = await _client.GetUserAsync(Constants.OwnerId).ConfigureAwait(false);
            var dmChannel = await _client.CreateDmAsync(user).ConfigureAwait(false);

            await _client.SendMessageAsync(dmChannel, $"Bot has received a new friend request\n```json\n{eventArgs.Json}```");
        }

        public async Task RunAsync()
        {
            if (_client is null) await InitializeAsync();

            commands = _client.UseCommandsNext(new CommandsNextConfiguration
            {
                EnableDms = true,
                CaseSensitive = false,
                EnableDefaultHelp = true,
                EnableMentionPrefix = true,
                IgnoreExtraArguments = false,
                StringPrefix = "!",
                Dependencies = ConfigureDependencies()
            });

            _voice = _client.UseVoiceNext(new VoiceNextConfiguration()
            {
                VoiceApplication = VoiceApplication.Music
            });

            commands.RegisterAllCommands();

            await _client.ConnectAsync();
            await Task.Delay(-1);
        }

        private DependencyCollection ConfigureDependencies()
        {
            var builder = new DependencyCollectionBuilder();

            builder.AddInstance(new GroupContextService());

            return builder.Build();
        }

        public async Task StopAsync()
        {
            await _client.DisconnectAsync();
            Environment.Exit(0);
        }
    }
}
