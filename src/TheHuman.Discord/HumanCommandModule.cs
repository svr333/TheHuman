using DSharpPlus.CommandsNext;
using System.Threading.Tasks;

namespace TheHuman.Discord
{
    public class HumanCommandModule
    {
        public Task BeforeExecutionAsync(CommandContext ctx)
            => Task.Delay(0);

        public Task AfterExecutionAsync(CommandContext ctx)
            => Task.Delay(0);
    }
}
