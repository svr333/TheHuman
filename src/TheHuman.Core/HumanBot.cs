using System.Threading.Tasks;

namespace TheHuman.Core
{
    public class HumanBot
    {
        private readonly IHumanClient _client;

        public HumanBot(IHumanClient client)
        {
            _client = client;
        }

        public async Task StartAsync()
        {
            await _client.RunAsync();
        }
    }
}