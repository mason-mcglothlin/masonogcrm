using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasonOgCRM.WebApp.Helpers
{
	public static class RazorPageHelperExtensions
	{
		/// <summary>
		/// Removes the suffer "Controller" from a controller name. For example, "CustomersController" becomes "Customers".
		/// </summary>
		/// <param name="controllerName">Controller name that ends in Controller</param>
		/// <returns>A string representing the controller name without the Controller suffix.</returns>
		public static string RemoveControllerFromName(this string controllerName)
		{
			return controllerName.Replace("Controller", "");
		}
	}
}
