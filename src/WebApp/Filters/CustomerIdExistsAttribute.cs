using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MasonOgCRM.DataAccess.Common;
using MasonOgCRM.WebApp.Helpers;
using Ninject;

namespace MasonOgCRM.WebApp.Filters
{
	public class CustomerIdExistsAttribute : ActionFilterAttribute
	{
		[Inject]
		public IOgCRMRepository Repository { get; set; }

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var idObj = filterContext.RouteData.Values["id"];
			if (idObj != null)
			{
				var idStr = idObj.ToString();
				var id = -1;
				if (Int32.TryParse(idStr, out id))
				{
					try
					{
						var customer = Repository.FindCustomerById(id);
						if (customer == null)
						{
							//id doesn't exist in the database or some error occured while loading
							filterContext.Result = new CustomViewResult("NotFound");
						}
					}
					catch (Exception)
					{
						//id doesn't exist in the database or some error occured while loading
						filterContext.Result = new CustomViewResult("NotFound");
					}

				}
				else
				{
					//id is not a valid int
					filterContext.Result = new CustomViewResult("NotFound");
				}
			}
			else
			{
				//id is missing
				filterContext.Result = new CustomViewResult("NotFound");
			}
		}
	}
}
