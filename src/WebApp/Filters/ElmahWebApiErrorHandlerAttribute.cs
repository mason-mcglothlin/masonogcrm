using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace MasonOgCRM.WebApp.Filters
{
	/// <summary>
	/// Filter to apply to Web API action methods so that when an error is unhandled, the exception will get logged with Elmah.
	/// </summary>
	public class ElmahWebApiErrorHandlerAttribute : ExceptionFilterAttribute
	{
		/// <summary>
		/// Method that runs when an exception is uncaught in a Web API action method to log the error with elmah.
		/// </summary>
		/// <param name="context">Context containing details about the exception and the application state.</param>
		public override void OnException(HttpActionExecutedContext context)
		{
			Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(context.Exception));
		}
	}
}
