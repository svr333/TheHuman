using Discord.Commands;
using System.Threading.Tasks;
using TheHuman.Commands;

namespace TheHuman.Discord.Modules
{
    public class TestCommands : HumanModule<SocketCommandContext>
    {
        [Command("ping")]
        public async Task TestCommand()
        {
            await ReplyAsync("pong");
        }

        [Command("create")]
        public async Task Play()
        {
            var user = Context.Client.GetUser(202095042372829184);
            var dmChannel = await user.GetOrCreateDMChannelAsync();

            await dmChannel.SendMessageAsync($"Gotcha fam");
        }
    }
}
