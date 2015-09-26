using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MasonOgCRM.DataAccess.Common;
using Ninject;

namespace MasonOgCRM.WebApp.Filters
{
	public class CustomerIdExistsAttribute : ActionFilterAttribute
	{
		[Inject]
		public IOgCRMRepository Repository { get; set; }

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var idStr = filterContext.RouteData.Values["id"].ToString();
			if (idStr != null)
			{
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
