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
	/// <summary>
	/// MVC Controller for interacting with Customers.
	/// </summary>
	public class CustomersController : Controller
	{
		private readonly IOgCRMRepository Repository;

		/// <summary>
		/// Creates an instance of the Customers controller with required dependencies.
		/// </summary>
		/// <param name="repository">Repository to perform CRUD against for customer objects.</param>
		public CustomersController(IOgCRMRepository repository)
		{
			Repository = repository;
		}

		/// <summary>
		/// Main customers list page.
		/// </summary>
		/// <returns>View with model representing all the customers in the system.</returns>
		public ActionResult Index()
		{
			var vm = new CustomersIndexViewModel()
			{
				AllCustomersList = Repository.GetAllCustomers()
			};
            return View(vm);
		}

		/// <summary>
		/// Page for creating a new customer.
		/// </summary>
		/// <returns>View for creating a new customer.</returns>
		public ActionResult New()
		{
			return View();
		}

		/// <summary>
		/// Action method where new customers are posted against.
		/// </summary>
		/// <param name="customer">Model representing new customer to be added to the repository.</param>
		/// <returns>A redirect to the Index action.</returns>
		public ActionResult Create(Customer customer)
		{
			Repository.AddCustomer(customer);
			return RedirectToAction(nameof(CustomersController.Index));
		}

		/// <summary>
		/// Details page for a customer.
		/// </summary>
		/// <param name="id">Id of the customer to view details for.</param>
		/// <returns>A view with the model of the specified customer.</returns>
		[CustomerIdExists]
		public ActionResult Details(int id)
		{
			return View(Repository.FindCustomerById(id));
		}
	}
}