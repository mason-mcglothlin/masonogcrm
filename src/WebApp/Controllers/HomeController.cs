using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MasonOgCRM.DataAccess.Common;
using MasonOgCRM.DomainModels;

namespace MasonOgCRM.WebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IOgCRMRepository Repository;

		public HomeController(IOgCRMRepository repository)
		{
			Repository = repository;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult DemoSetup()
		{
			return View();
		}

		public ActionResult PerformSeed()
		{
			var tasks = new List<Task>();

			tasks.Add(Repository.AddCustomerAsync(new Customer() { FirstName = "Nancy", LastName = "Stevens", CompanyName = "Acme Inc", PhoneNumber = "111-111-1111", Address = "1 Harvard Way", EmailAddress = "nancy@harvard.com" }));
			tasks.Add(Repository.AddCustomerAsync(new Customer() { FirstName = "Bob", LastName = "McInnis", CompanyName = "Ghostbusters LLC", PhoneNumber = "214-787-1037", Address = "2 New York City", EmailAddress = "bob@ghostbusters.net" }));
			tasks.Add(Repository.AddCustomerAsync(new Customer() { FirstName = "Larry", LastName = "Daly", CompanyName = "Daly, Daly, and Daly PLLC", PhoneNumber = "222-222-2222", Address = "1 West Street", EmailAddress = "larry.daly@daly.biz" }));
			tasks.Add(Repository.AddCustomerAsync(new Customer() { FirstName = "Steve", LastName = "Martin", CompanyName = "Apple Inc", PhoneNumber = "333-333-3333", Address = "West 7th Street", EmailAddress = "steve@apple.com" }));
			tasks.Add(Repository.AddCustomerAsync(new Customer() { FirstName = "Neil", LastName = "Armstrong", CompanyName = "Spacecract Components Ciro", PhoneNumber = "444-444-4444", Address = "5 Commerce Ave", EmailAddress = "neilonmoon@nasa.gov" }));
			tasks.Add(Repository.AddCustomerAsync(new Customer() { FirstName = "Harry", LastName = "Potter", CompanyName = "Daily Prophet GmhB", PhoneNumber = "555-555-5555", Address = "4 Privet Drive", EmailAddress = "harry@magicmail.com" }));
			tasks.Add(Repository.AddCustomerAsync(new Customer() { FirstName = "Henry", LastName = "Ford", CompanyName = "Ford Motors Corporation", PhoneNumber = "666-666-6666", Address = "9 East Rosedale Ave", EmailAddress = "henry@ford.com" }));
			tasks.Add(Repository.AddCustomerAsync(new Customer() { FirstName = "Dave", LastName = "Hal", CompanyName = "National Smithsonian Museums LLC", PhoneNumber = "777-777-7777", Address = "1600 Penn Ave", EmailAddress = "dave@gmail.com" }));
			tasks.Add(Repository.AddCustomerAsync(new Customer() { FirstName = "Mason", LastName = "McGlothlin", CompanyName = "Oil and Gas Information Systems", PhoneNumber = "888-888-8888", Address = "10 River Park Drive", EmailAddress = "mason@masonmcg.com" }));
			tasks.Add(Repository.AddCustomerAsync(new Customer() { FirstName = "John", LastName = "Woo", CompanyName = "Landsberg Co", PhoneNumber = "999-999-9999", Address = "8444 South Hill St", EmailAddress = "john@landsberg.com" }));

			tasks.Add(Repository.AddUserAccountAsync(new UserAccount() { FirstName = "Jane", LastName = "Kniclebocker", EmailAddress = "jane@ogsys.com" }));
			tasks.Add(Repository.AddUserAccountAsync(new UserAccount() { FirstName = "Jimmy", LastName = "Hendrix", EmailAddress = "jimmy@ogsys.com" }));
			tasks.Add(Repository.AddUserAccountAsync(new UserAccount() { FirstName = "Johnathan", LastName = "Lane", EmailAddress = "john@ogsys.com" }));
			tasks.Add(Repository.AddUserAccountAsync(new UserAccount() { FirstName = "Jorge", LastName = "Mendez", EmailAddress = "jorge@ogsys.com" }));
			tasks.Add(Repository.AddUserAccountAsync(new UserAccount() { FirstName = "Jade", LastName = "Fire", EmailAddress = "jade@ogsys.com" }));

			Task.WaitAll(tasks.ToArray());
			return RedirectToAction(nameof(HomeController.Index));
		}

		public async Task<ActionResult> PerformEmpty()
		{
			var tasks = new List<Task>();

			foreach (var id in await Repository.GetAllCustomerIdsAsync())
			{
				tasks.Add(Repository.DeleteCustomerAsync(id));
			}

			foreach (var id in await Repository.GetAllUserAccountIdsAsync())
			{
				tasks.Add(Repository.DeleteUserAccountAsync(id));
			}

			Task.WaitAll(tasks.ToArray());
			return RedirectToAction(nameof(HomeController.Index));
		}
	}
}