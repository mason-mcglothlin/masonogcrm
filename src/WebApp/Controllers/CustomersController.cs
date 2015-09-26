using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MasonOgCRM.DataAccess.Common;
using MasonOgCRM.DomainModels;
using MasonOgCRM.WebApp.Filters;

namespace MasonOgCRM.WebApp.Controllers
{
	public class CustomersController : Controller
	{
		private readonly IOgCRMRepository Repository;

		public CustomersController(IOgCRMRepository repository)
		{
			Repository = repository;
		}

		public async Task<ActionResult> Index()
		{
			return View(await Repository.GetAllCustomersAsync());
		}

		public ActionResult New()
		{
			return View();
		}

		public async Task<ActionResult> Create(Customer customer)
		{
			await Repository.AddCustomerAsync(customer);
			return RedirectToAction(nameof(CustomersController.Index));
		}

		[CustomerIdExists]
		public async Task<ActionResult> Details(int id)
		{
			return View(await Repository.FindCustomerByIdAsync(id));
		}
	}
}