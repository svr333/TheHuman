using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using TheHuman.Discord.Preconditions;

namespace TheHuman.Discord.Modules
{
    public class TestCommands
    {
        [Command("ping")][RequireGroupContext]
        public async Task TestCommand(CommandContext context)
        {
            await context.RespondAsync("pong!");
        }
    }
}
