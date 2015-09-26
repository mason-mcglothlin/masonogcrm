using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MasonOgCRM.DataAccess.Common;
using MasonOgCRM.WebApp.ViewModels;
using Ninject;

namespace MasonOgCRM.WebApp.Filters
{
	public class LayoutViewModelInjectorAttribute : ActionFilterAttribute
	{
		private readonly IOgCRMRepository Repository;

		public LayoutViewModelInjectorAttribute(IOgCRMRepository repository)
		{
			Repository = repository;
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var result = filterContext.Result;
			if (result is ViewResult)
			{
				var layoutViewModel = new LayoutViewModel()
				{
					NumberOfCustomers = Repository.GetCustomerTotalCount(),
					NumberOfUserAccounts = 21
				};
				(result as ViewResult).ViewBag.LayoutViewModel = layoutViewModel;
			}
		}
	}
}
