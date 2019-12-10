using System.Collections.Concurrent;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace TheHuman.Discord.Preconditions
{
    public class RequireGroupContextAttribute : CheckBaseAttribute
    {
        private ConcurrentDictionary<ulong, ulong> _context = new ConcurrentDictionary<ulong, ulong>();

        private bool UserHasContext(CommandContext ctx)
        {
            if (_context.TryGetValue(ctx.User.Id, out var channelId) && channelId != ctx.Channel.Id)
            {
                
            }
        }

        public override Task<bool> CanExecute(CommandContext ctx, bool help)
        {
            return Task.FromResult(UserHasContext(ctx));
        }
    }
}
