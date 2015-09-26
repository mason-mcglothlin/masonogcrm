using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MasonOgCRM.WebApp.Filters
{
	public class CustomViewResult : ViewResult
	{
		/// <summary>
		/// Helper class for returning a view from an MVC filter.
		/// </summary>
		/// <param name="viewName">The view name to return.</param>
		public CustomViewResult(string viewName)
		{
			ViewName = viewName;
		}
	}
}
