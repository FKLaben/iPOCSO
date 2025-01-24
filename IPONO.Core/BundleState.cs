namespace IPONO.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum BundleState
    {
        Installed,
        Resolved,
        Starting,
        Active,
        Stopping,
        Uninstalled
    }
}
