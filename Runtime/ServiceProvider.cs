using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Misaki.UIToolkit
{
    public class ServiceProvider : IServiceProvider
    {
        private readonly ConcurrentDictionary<Type, ServiceDescriptor> _services = new();

        public ServiceProvider(IServiceCollection collection)
        {
            foreach (var item in collection)
            {
                if (_services.ContainsKey(item.ServiceType))
                {
                    throw new Exception($"Service of type {item.ServiceType.Name} is already registered.");
                }

                _services.TryAdd(item.ServiceType, item);
            }
        }

        public object GetService(Type serviceType)
        {
            if (_services.TryGetValue(serviceType, out var descriptor))
            {
                if (descriptor.Lifetime == ServiceLifetime.Singleton)
                {
                    descriptor.Implementation ??= CreateInstance(descriptor.ImplementationType);
                    return descriptor.Implementation;
                }

                // For Transient, always create a new instance
                return CreateInstance(descriptor.ImplementationType);
            }

            throw new Exception($"Service of type {serviceType.Name} not recognize.");
        }

        private object CreateInstance(Type implementationType)
        {
            var constructor = implementationType.GetConstructors().First();
            var parameters = constructor.GetParameters();
            var parameterInstances = parameters.Select(p => GetService(p.ParameterType)).ToArray();
            return Activator.CreateInstance(implementationType, parameterInstances);
        }
    }
}
