using System.Threading.Tasks;

namespace TheHuman.Core
{
    public interface IHumanClient
    {
        Task RunAsync();
        Task StopAsync();
    }
}
