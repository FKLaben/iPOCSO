namespace IPONO.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BundleContext
    {
        private readonly IServiceRegistry _serviceRegistry;
        public string BundleId { get; }

        public BundleContext(IServiceRegistry serviceRegistry, string bundleId)
        {
            _serviceRegistry = serviceRegistry;
            BundleId = bundleId;
        }

        public void RegisterService<T>(T service) where T : class
        {
            _serviceRegistry.RegisterService(BundleId, service);
        }

        public void UnregisterService<T>() where T : class
        {
            _serviceRegistry.UnregisterService<T>(BundleId);
        }

        public T GetService<T>() where T : class
        {
            return _serviceRegistry.GetService<T>();
        }

        public IEnumerable<T> GetServices<T>() where T : class
        {
            return _serviceRegistry.GetServices<T>();
        }
    }
}
