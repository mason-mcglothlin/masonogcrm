using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MasonOgCRM.DataAccess.Common;
using MasonOgCRM.DomainModels;
using MasonOgCRM.WebApp.Filters;
using MasonOgCRM.WebApp.ViewModels;

namespace MasonOgCRM.WebApp.Controllers
{
	public class CustomersController : Controller
	{
		private readonly IOgCRMRepository Repository;

		public CustomersController(IOgCRMRepository repository)
		{
			Repository = repository;
		}

		public ActionResult Index()
		{
			var vm = new CustomersIndexViewModel()
			{
				AllCustomersList = Repository.GetAllCustomers()
			};
            return View(vm);
		}

		public ActionResult New()
		{
			return View();
		}

		public ActionResult Create(Customer customer)
		{
			Repository.AddCustomer(customer);
			return RedirectToAction(nameof(CustomersController.Index));
		}

		[CustomerIdExists]
		public ActionResult Details(int id)
		{
			return View(Repository.FindCustomerById(id));
		}
	}
}