using System.Threading.Tasks;

namespace TheHuman.Core
{
    public interface IHumanClient
    {
        Task InitializeAsync();
        Task RunAsync();
        Task StopAsync();
    }
}
