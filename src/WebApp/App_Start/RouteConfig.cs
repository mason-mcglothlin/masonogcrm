using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace MasonOgCRM.WebApp.App_Start
{
	/// <summary>
	/// Class to configure routes for MVC in the application.
	/// </summary>
	public class RouteConfig
	{
		/// <summary>
		/// Registers routes with the MVC framework by modifying the RouteCollection.
		/// </summary>
		/// <param name="routes">Collection of routes for the routes to be added to.</param>
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new
				{
					controller = "Home",
					action = "Index",
					id = UrlParameter.Optional
				}
			);
		}
	}
}
