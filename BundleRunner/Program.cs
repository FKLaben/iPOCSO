namespace BundleRunner
{
    using System;
    using System.Reflection;
    using System.Reflection.Metadata;
    using AppBundle;
    using IPONO.Core;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Dynamically load the ApplicationBundle assembly
                Assembly bundleAssembly = LoadBundle("AppBundle.dll");

                // Create bundle manager and context
                var bundleManager = new BundleManager();
                var bundleContext = bundleManager.CreateBundleContext();

                // Create bundle dynamically
                object bundleInstance = CreateBundleInstance(bundleAssembly, bundleContext);

                // Install the bundle
                if (bundleInstance is Bundle bundle)
                {
                    bundleManager.InstallBundle(bundle);

                    // Start all bundles
                    bundleManager.StartAllBundles();

                    // Run the application service if available
                    InvokeApplicationService(bundleInstance);

                    // Stop all bundles
                    bundleManager.StopAllBundles();
                }
                else
                {
                    Console.WriteLine("Failed to create bundle instance.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running bundle: {ex.Message}");
            }
        }

        static Assembly LoadBundle(string assemblyName)
        {
            try
            {
                // Load the assembly from the specified path
                return Assembly.LoadFrom(assemblyName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load bundle assembly: {ex.Message}");
                throw;
            }
        }

        static object CreateBundleInstance(Assembly assembly, BundleContext context)
        {
            // Find the ApplicationBundle type
            Type bundleType = assembly.GetTypes()
                .FirstOrDefault(t => typeof(Bundle).IsAssignableFrom(t) && !t.IsAbstract);

            if (bundleType == null)
            {
                throw new Exception("No Bundle type found in the assembly");
            }

            // Create an instance of the bundle
            return Activator.CreateInstance(bundleType, context);
        }

        static void InvokeApplicationService(object bundleInstance)
        {
            // Try to invoke the RunApplication method if the bundle implements IApplicationService
            IApplicationService appService = bundleInstance as IApplicationService;
            appService?.RunApplication();
        }
    }
}