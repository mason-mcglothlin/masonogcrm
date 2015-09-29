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
	/// <summary>
	/// Filter that can be applied to MVC action methods to ensure that the Layout shared view receives the necessary view model.
	/// </summary>
	public class LayoutViewModelInjectorAttribute : ActionFilterAttribute
	{
		private readonly IOgCRMRepository Repository;

		/// <summary>
		/// Create an instance of this filter with the necessary dependencies.
		/// </summary>
		/// <param name="repository">Repository to retrieve data about the application from.</param>
		public LayoutViewModelInjectorAttribute(IOgCRMRepository repository)
		{
			Repository = repository;
		}

		/// <summary>
		/// If the result of an action method is a ViewResult, this retrieves data from the Repository about the number of 
		/// customers and user accounts in the database, adds them to a view model, and injects them into the View Bag.
		/// </summary>
		/// <param name="filterContext">Information about the result of executing the action method.</param>
		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			var result = filterContext.Result;
			if (result is ViewResult)
			{
				var layoutViewModel = new LayoutViewModel()
				{
					NumberOfCustomers = Repository.GetCustomerTotalCount(),
					NumberOfUserAccounts = Repository.GetUserAccountTotalCount()
				};
				(result as ViewResult).ViewBag.LayoutViewModel = layoutViewModel;
			}
		}	
	}
}
