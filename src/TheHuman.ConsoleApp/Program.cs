using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TheHuman.Core;
using TheHuman.IOC;

namespace TheHuman.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
            => MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();

        static async Task MainAsync(string[] args)
        {
            var services = new ServiceCollection().AddBotServices().BuildServiceProvider();
            var client = services.GetRequiredService<IHumanClient>();
            
            await client.RunAsync();
        }
    }
}
