using System;

namespace Misaki.DependencyInjection
{
    public class HostBuilder
    {
        private ServiceCollection _serviceCollection = new();

        public HostBuilder ConfigureServices(Action<IServiceCollection> configureServices)
        {
            configureServices(_serviceCollection);
            return this;
        }

        public IHost Build()
        {
            var serviceProvider = new ServiceProvider(_serviceCollection);
            return new Host(serviceProvider);
        }
    }
}