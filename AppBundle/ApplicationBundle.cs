namespace AppBundle
{
    using IPONO.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ApplicationBundle : Bundle, IApplicationService
    {
        public ApplicationBundle(BundleContext context) : base(context) { }

        protected override void OnStart()
        {
            // var logService = Context.GetService<ILogService>();
            // logService?.Log("Application Bundle Started");
        }

        protected override void OnStop()
        {
            //var logService = Context.GetService<ILogService>();
            //logService?.Log("Application Bundle Stopped");
        }

        public void RunApplication()
        {
            Console.WriteLine("Application Bundle is running its main functionality!");

            // Example of using a service
            // var logService = Context.GetService<ILogService>();
            // logService?.Log("Running main application logic");
        }
    }
}
