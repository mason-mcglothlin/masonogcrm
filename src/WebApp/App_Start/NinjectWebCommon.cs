[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MasonOgCRM.WebApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MasonOgCRM.WebApp.App_Start.NinjectWebCommon), "Stop")]

namespace MasonOgCRM.WebApp.App_Start
{
	using System;
	using System.Configuration;
	using System.Web;
	using System.Web.Mvc;
	using DataAccess.Common;
	using DataAccess.EF;
	using DataAccess.InMemory;
	using Filters;
	using Microsoft.Web.Infrastructure.DynamicModuleHelper;
	using Ninject;
	using Ninject.Web.Common;
	using Ninject.Web.Mvc.FilterBindingSyntax;

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
			kernel.BindFilter<LayoutViewModelInjectorAttribute>(FilterScope.Global, 0);
			kernel.BindFilter<HandleErrorAttribute>(FilterScope.Global, 0);
			kernel.BindFilter<AuthorizeAttribute>(FilterScope.Global, 0);
			kernel.Bind<IPasswordHasher>().To<PasswordHasher>();

			if (ConfigurationManager.AppSettings["Repository"] != null)
			{
				if (ConfigurationManager.AppSettings["Repository"] == "InMemory")
				{
					RegisterInMemoryRepository(kernel);
				}
				else if (ConfigurationManager.AppSettings["Repository"] == "SqlServerLocalDatabase")
				{
					RegisterEFRepository(kernel);
				}
				else
				{
					throw new ApplicationException("Invalid appSetting for Repository. Valid values are SqlServerLocalDatabase and InMemeory.");
				}
			}
			else
			{
				throw new ApplicationException("Unsure of what repository to use. Configure appSettings Repository key with SqlServerLocalDatabase or InMemory.");
			}
		}

		private static void RegisterEFRepository(IKernel kernel)
		{
			var dbContext = new EFDBContext("SqlServerLocalDb");
			kernel.Bind<IOgCRMRepository>().ToMethod((IContext) => new EntityFrameworkRepository(dbContext, new PasswordHasher()));
		}

		private static void RegisterInMemoryRepository(IKernel kernel)
		{
			kernel.Bind<IOgCRMRepository>().To<InMemoryRepository>().InSingletonScope();
		}
	}
}
