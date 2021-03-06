[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Btk.CaaS.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Btk.CaaS.App_Start.NinjectWebCommon), "Stop")]

namespace Btk.CaaS.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Btk.CaaS.Core;
    using Btk.CaaS.Core.Fortune;
    using Btk.CaaS.Core.Cowsay;
    using Btk.CaaS.Core.Cowsay.Avatars;
    using Btk.CaaS.Controllers;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IFortuneProvider>().To<TcpFortuneProvider>().WithConstructorArgument("alpha.mike-r.com").WithConstructorArgument(17);
            kernel.Bind<Cow>().ToSelf();
            kernel.Bind<IAvatarDrawer>().To<CowAvatar>();
            kernel.Bind<ILineBreaker>().To<WordWrappingLineBreaker>().WithConstructorArgument(70);
            kernel.Bind<IReleaseService>().To<ReleaseService>().WithConstructorArgument(new DateTime(2014,11,22,23,0,0));
        }        
    }
}
