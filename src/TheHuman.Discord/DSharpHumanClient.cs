using System;
using TheHuman.Core;
using System.Threading.Tasks;

namespace TheHuman.Discord
{
    public class DSharpHumanClient : IHumanClient
    {
        private DiscordClient _client;

        public async Task InitializeClient()
        {
            if (_client is {}) return;

            _client = new DiscordClient(new DiscordConfiguration
                {
                    Token = Environment.GetEnvironmentVariable("HumanToken"),
                    TokenType = TokenType.User,
                    
                });
        }

        public async Task ConnectToDiscordAsync(string username, string password)
        {
            
        }

        public async Task RunAsync()
        {

        }

        public async Task DisconnectFromDiscordAsync()
        {
            throw new NotImplementedException();
        }
    }
}
