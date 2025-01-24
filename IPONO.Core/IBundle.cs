namespace IPONO.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBundle
    {
        string BundleId { get; }
        BundleState State { get; }
        void Start();
        void Stop();
    }
}
