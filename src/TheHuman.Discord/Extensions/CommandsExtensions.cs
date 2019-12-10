using DSharpPlus.CommandsNext;
using TheHuman.Discord.Modules;

namespace TheHuman.Discord.Extensions
{
    public static class CommandsExtensions
    {
        public static void RegisterAllCommands(this CommandsNextModule commands)
        {
            commands.RegisterCommands<TestCommands>();
            commands.RegisterCommands<ContextCommands>();
        }
    }
}