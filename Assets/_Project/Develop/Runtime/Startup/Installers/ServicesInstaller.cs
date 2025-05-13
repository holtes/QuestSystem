using _Project.Develop.Runtime.Domain.Shared.Services;

namespace _Project.Develop.Runtime.Startup.Installers
{
    public class ServicesInstaller
    {
        public TimeService TimeService { get; private set; }

        public void Init()
        {
            TimeService = new TimeService();
        }
    }
}