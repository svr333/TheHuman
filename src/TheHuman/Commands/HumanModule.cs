using Discord.Commands;

namespace TheHuman.Commands
{
    public class HumanModule<T> : ModuleBase<T> where T : class, ICommandContext
    {
        protected ICommandContext ctx => Context;

        protected override void BeforeExecute(CommandInfo command)
        {
            
        }

        protected override void AfterExecute(CommandInfo command)
        {

        }
    }
}
