using System;

namespace TheHuman.Core
{
    public interface IHumanClient
    {
        Task ConnectToDiscordAsync(string username, string password);
        Task RunAsync();
        Task DisconnectFromDiscordAsync();
    }
}
