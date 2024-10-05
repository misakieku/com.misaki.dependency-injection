using System.IO;
using UnityEngine;

namespace Misaki.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static void AddSingleton<TService, TImplementation>(this IServiceCollection collection) where TService : class
        {
            collection.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
        }

        public static void AddSingleton<TService>(this IServiceCollection collection) where TService : class
        {
            collection.Add(new ServiceDescriptor(typeof(TService), typeof(TService), ServiceLifetime.Singleton));
        }

        public static void AddTransient<TService, TImplementation>(this IServiceCollection collection) where TService : class
        {
            collection.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
        }

        public static void AddTransient<TService>(this IServiceCollection collection) where TService : class
        {
            collection.Add(new ServiceDescriptor(typeof(TService), typeof(TService), ServiceLifetime.Transient));
        }

        public static void Config<TConfig>(this IServiceCollection collection, TConfig configInstance) where TConfig : ScriptableObject
        {
            collection.Add(new ServiceDescriptor(typeof(IOptions<TConfig>), typeof(TConfig), ServiceLifetime.Singleton, new Options<TConfig>(configInstance)));
        }

        public static void ConfigFromJson<TConfig>(this IServiceCollection collection, string configPath) where TConfig : class
        {
            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException($"Configuration file not found: {configPath}");
            }

            var json = File.ReadAllText(configPath);
            var configInstance = JsonUtility.FromJson<TConfig>(json);

            collection.Add(new ServiceDescriptor(typeof(TConfig), typeof(TConfig), ServiceLifetime.Singleton, configInstance));
        }
    }
}