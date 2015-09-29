using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MasonOgCRM.WebApp.Helpers
{
	/// <summary>
	/// Helper method provided with the Insignia layout for determining the active page and modifying the CSS class based on MVC route data.
	/// </summary>
	public static class HMTLHelperExtensions
	{
		/// <summary>
		/// If the Controller and Action specified as paramters match the current route, returns a CssClass to mark HTML elements as active with.
		/// </summary>
		/// <param name="html">Information about the context.</param>
		/// <param name="controller">The controller to compare the current controller against.</param>
		/// <param name="action">The action to compare the current controller against.</param>
		/// <returns></returns>
		public static string IsSelected(this HtmlHelper html, string controller = null, string action = null)
		{
			string cssClass = "active";
			string currentAction = (string)html.ViewContext.RouteData.Values["action"];
			string currentController = (string)html.ViewContext.RouteData.Values["controller"];

			if (String.IsNullOrEmpty(controller))
				controller = currentController;

			if (String.IsNullOrEmpty(action))
				action = currentAction;

			return controller == currentController && action == currentAction ?
				cssClass : String.Empty;
		}
	}
}
