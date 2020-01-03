using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace TheHuman.Commands
{
    public class CommandHandler
    {
        private readonly CommandService _commands;
        private readonly IServiceProvider _services;
        private readonly DiscordSocketClient _client;

        public CommandHandler(CommandService commands, IServiceProvider services, DiscordSocketClient client)
        {
            _commands = commands;
            _services = services;
            _client = client;
        }

        public async Task InitializeAsync()
        {
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += OnMessageReceived;
        }

        private async Task OnMessageReceived(SocketMessage m)
        {
            if (!(m is SocketUserMessage message)) return;

            var context = new SocketCommandContext(_client, message);
            var result = await _commands.ExecuteAsync(context, 0, _services);
        }
    }
}
