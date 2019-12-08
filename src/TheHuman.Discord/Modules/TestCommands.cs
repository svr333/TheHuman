using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace TheHuman.Discord.Modules
{
    public class TestCommands
    {
        [Command("ping")]
        public async Task TestCommand(CommandContext context)
        {
            await context.RespondAsync("pong!");
        }
    }
}
