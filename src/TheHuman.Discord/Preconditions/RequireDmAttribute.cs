using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using TheHuman.Core;

namespace TheHuman.Discord.Preconditions
{
    public class RequireGroupContextAttribute : CheckBaseAttribute
    {
        public override Task<bool> ExecuteCheckAsync(CommandContext ctx, bool help) 
        {
            var context = ctx.Services.GetService(typeof(GroupContextService)) as GroupContextService;

            return Task.FromResult(context.UserHasContext(ctx.User.Id));
        }
    }
}
