using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using TheHuman.Core;

namespace TheHuman.Discord.Modules
{
    public class TestCommands : BaseCommandModule
    {
        [Command("ping")]
        public async Task TestCommand(CommandContext context)
        {
            await context.RespondAsync("pong!");
        }

        [Command("create")]
        public async Task Play(CommandContext context)
        {
            var user = await context.Client.GetUserAsync(Constants.OwnerId).ConfigureAwait(false) as DiscordMember;
            var dmChannel = await user.CreateDmChannelAsync();

            await dmChannel.SendMessageAsync($"Gotcha fam");
        }
    }
}
