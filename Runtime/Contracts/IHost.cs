using System;
using System.Threading.Tasks;

namespace Misaki.DependencyInjection
{
    public interface IHost : IDisposable
    {
        public IServiceProvider Services
        {
            get;
        }

        public Task StartAsync();

        public Task StopAsync();
    }
}
