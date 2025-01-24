namespace IPOCSO.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Bundle implementation
    /// </summary>
    public abstract class Bundle : IBundle
    {
        protected BundleContext Context { get; }

        public string BundleId { get; }
        public BundleState State { get; protected set; }

        protected Bundle(BundleContext context)
        {
            Context = context;
            BundleId = Guid.NewGuid().ToString();
            State = BundleState.Installed;
        }

        public virtual void Start()
        {
            if (State == BundleState.Installed)
            {
                State = BundleState.Starting;
                OnStart();
                State = BundleState.Active;
            }
        }

        public virtual void Stop()
        {
            if (State == BundleState.Active)
            {
                State = BundleState.Stopping;
                OnStop();
                State = BundleState.Uninstalled;
            }
        }

        protected abstract void OnStart();
        protected abstract void OnStop();
    }
}
