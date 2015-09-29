using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using MasonOgCRM.WebApp.Filters;

namespace MasonOgCRM.WebApp.App_Start
{
	/// <summary>
	/// Class for configuration of Web API settings
	/// </summary>
	public static class WebApiConfig
	{
		/// <summary>
		/// Sets up Web API routes and filters.
		/// </summary>
		/// <param name="config">Configuration object to register the settings with.</param>
		public static void Register(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			config.Filters.Add(new ElmahWebApiErrorHandlerAttribute());

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
