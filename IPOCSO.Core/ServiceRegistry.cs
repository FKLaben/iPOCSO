namespace IPOCSO.Core
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ServiceRegistry : IServiceRegistry
    {
        // Concurrent dictionary for thread-safe service management
        private readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, object>> _services
            = new ConcurrentDictionary<Type, ConcurrentDictionary<string, object>>();

        public void RegisterService<T>(string bundleId, T service) where T : class
        {
            var serviceType = typeof(T);
            _services.AddOrUpdate(
                serviceType,
                _ => new ConcurrentDictionary<string, object>() { [bundleId] = service },
                (_, existing) =>
                {
                    existing[bundleId] = service;
                    return existing;
                }
            );
        }

        public void UnregisterService<T>(string bundleId) where T : class
        {
            var serviceType = typeof(T);
            if (_services.TryGetValue(serviceType, out var bundleServices))
            {
                bundleServices.TryRemove(bundleId, out _);
            }
        }

        public T GetService<T>() where T : class
        {
            var serviceType = typeof(T);
            if (_services.TryGetValue(serviceType, out var bundleServices) && bundleServices.Count > 0)
            {
                return (T)bundleServices.Values.First();
            }
            return null;
        }

        public IEnumerable<T> GetServices<T>() where T : class
        {
            var serviceType = typeof(T);
            if (_services.TryGetValue(serviceType, out var bundleServices))
            {
                return bundleServices.Values.Cast<T>();
            }
            return Enumerable.Empty<T>();
        }
    }
}
