namespace IPONO.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IServiceRegistry
    {
        void RegisterService<T>(string bundleId, T service) where T : class;
        void UnregisterService<T>(string bundleId) where T : class;
        T GetService<T>() where T : class;
        IEnumerable<T> GetServices<T>() where T : class;
    }
}
