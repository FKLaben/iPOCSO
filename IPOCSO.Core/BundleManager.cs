namespace IPOCSO.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Bundle manager to manage Bundle lifecycle
    /// </summary>
    public class BundleManager
    {
        private readonly IServiceRegistry _serviceRegistry;
        private readonly List<IBundle> _bundles = new List<IBundle>();

        public BundleManager()
        {
            _serviceRegistry = new ServiceRegistry();
        }

        public BundleContext CreateBundleContext()
        {
            return new BundleContext(_serviceRegistry, Guid.NewGuid().ToString());
        }

        public void InstallBundle(IBundle bundle)
        {
            _bundles.Add(bundle);
        }

        public void StartAllBundles()
        {
            foreach (var bundle in _bundles.Where(b => b.State == BundleState.Installed))
            {
                bundle.Start();
            }
        }

        public void StopAllBundles()
        {
            foreach (var bundle in _bundles.Where(b => b.State == BundleState.Active))
            {
                bundle.Stop();
            }
        }
    }
}
