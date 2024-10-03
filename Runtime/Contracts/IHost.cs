using System;
using System.Threading.Tasks;

namespace Misaki.UIToolkit
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
