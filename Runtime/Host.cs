using System;
using System.Threading.Tasks;

namespace Misaki.UIToolkit
{
    public class Host : IHost
    {
        public IServiceProvider Services
        {
            get;
        }

        public Host(IServiceProvider serviceProvider)
        {
            Services = serviceProvider;
        }

        public Task StartAsync()
        {
            return Task.CompletedTask;
        }

        public Task StopAsync()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {

        }

        public static HostBuilder CreateBuilder()
        {
            return new HostBuilder();
        }
    }
}
