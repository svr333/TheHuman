using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using TheHuman.Core;

namespace TheHuman.Discord
{
    public class ContextCommands : BaseCommandModule
    {
        private GroupContextService _context;

        public ContextCommands(GroupContextService context)
        {
            _context = context;
        }

        [Command("addcontext")][Aliases("context_add", "contextadd", "add_context")]
        public async Task ChangeContextCommand(CommandContext ctx, ulong channelId)
        {
            var dmChannel = await ctx.Client.GetChannelAsync(channelId).ConfigureAwait(false) as DiscordDmChannel;
            if (channelId is 0) { dmChannel = ctx.Channel as DiscordDmChannel; }

            _context.TrySetUserContext(ctx.User.Id, dmChannel.Id, out ulong oldGroupId);
            
            var privateChannel = dmChannel.Recipients.Count == 1 ? $"{dmChannel.Recipients[0].Username}" : $"{dmChannel.Name}";
            var message = oldGroupId is 0 ? $"Succes, context channel has been set to \"**{privateChannel}**\" ({dmChannel.Id})!"
                                            : $"Succces, context channel has been updated from *{oldGroupId}* to **{dmChannel.Name}** ({dmChannel.Id})";

            await ctx.RespondAsync($"{message}");
        }
        
        [Command("getcontext")][Aliases("context_get", "contextget", "get_context", "context")]
        public async Task GetContextCommand(CommandContext ctx)
        {
            if (!_context.UserHasContext(ctx.User.Id))
            {
                await ctx.RespondAsync("You have no context set.\nUse `!addcontext <channelID>`");
                return;
            }

            _context.TryGetUserContext(ctx.User.Id, out ulong groupId);

            var test = (ctx.Client.PrivateChannels as IList<DiscordDmChannel>);
            var dmChannel = test.FirstOrDefault(x => x.Id == groupId);

            if (dmChannel is null) 
            {
                await ctx.RespondAsync("The id you have set up is not correct or I'm not a member of that group yet.\n" +
                                        $"Please add me to the group or change your context with `!addcontext <channelID>`");
                return;
            }
            
            await ctx.RespondAsync($"Your current context is set to \"**{dmChannel.Name}**\" ({dmChannel.Id})\n" +
                                    $"This DmChat has {dmChannel.Recipients.Count} users.");
        }
    }
}
