namespace Misaki.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static void AddSingleton<TService, TImplementation>(this IServiceCollection collection)
        {
            collection.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
        }

        public static void AddSingleton<TService>(this IServiceCollection collection)
        {
            collection.Add(new ServiceDescriptor(typeof(TService), typeof(TService), ServiceLifetime.Singleton));
        }

        public static void AddTransient<TService, TImplementation>(this IServiceCollection collection)
        {
            collection.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
        }

        public static void AddTransient<TService>(this IServiceCollection collection)
        {
            collection.Add(new ServiceDescriptor(typeof(TService), typeof(TService), ServiceLifetime.Transient));
        }
    }
}