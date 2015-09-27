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
			Repository.AddCustomer(new Customer() { FirstName = "Nancy", LastName = "Stevens", CompanyName = "Acme Inc", PhoneNumber = "111-111-1111", Address = "1 Harvard Way", EmailAddress = "nancy@harvard.com" });
			Repository.AddCustomer(new Customer() { FirstName = "Bob", LastName = "McInnis", CompanyName = "Ghostbusters LLC", PhoneNumber = "214-787-1037", Address = "2 New York City", EmailAddress = "bob@ghostbusters.net" });
			Repository.AddCustomer(new Customer() { FirstName = "Larry", LastName = "Daly", CompanyName = "Daly, Daly, and Daly PLLC", PhoneNumber = "222-222-2222", Address = "1 West Street", EmailAddress = "larry.daly@daly.biz" });
			Repository.AddCustomer(new Customer() { FirstName = "Steve", LastName = "Martin", CompanyName = "Apple Inc", PhoneNumber = "333-333-3333", Address = "West 7th Street", EmailAddress = "steve@apple.com" });
			Repository.AddCustomer(new Customer() { FirstName = "Neil", LastName = "Armstrong", CompanyName = "Spacecract Components Ciro", PhoneNumber = "444-444-4444", Address = "5 Commerce Ave", EmailAddress = "neilonmoon@nasa.gov" });
			Repository.AddCustomer(new Customer() { FirstName = "Harry", LastName = "Potter", CompanyName = "Daily Prophet GmhB", PhoneNumber = "555-555-5555", Address = "4 Privet Drive", EmailAddress = "harry@magicmail.com" });
			Repository.AddCustomer(new Customer() { FirstName = "Henry", LastName = "Ford", CompanyName = "Ford Motors Corporation", PhoneNumber = "666-666-6666", Address = "9 East Rosedale Ave", EmailAddress = "henry@ford.com" });
			Repository.AddCustomer(new Customer() { FirstName = "Dave", LastName = "Hal", CompanyName = "National Smithsonian Museums LLC", PhoneNumber = "777-777-7777", Address = "1600 Penn Ave", EmailAddress = "dave@gmail.com" });
			Repository.AddCustomer(new Customer() { FirstName = "Mason", LastName = "McGlothlin", CompanyName = "Oil and Gas Information Systems", PhoneNumber = "888-888-8888", Address = "10 River Park Drive", EmailAddress = "mason@masonmcg.com" });
			Repository.AddCustomer(new Customer() { FirstName = "John", LastName = "Woo", CompanyName = "Landsberg Co", PhoneNumber = "999-999-9999", Address = "8444 South Hill St", EmailAddress = "john@landsberg.com" });

			Repository.AddUserAccount(new UserAccount() { FirstName = "Jane", LastName = "Kniclebocker", EmailAddress = "jane@ogsys.com" });
			Repository.AddUserAccount(new UserAccount() { FirstName = "Jimmy", LastName = "Hendrix", EmailAddress = "jimmy@ogsys.com" });
			Repository.AddUserAccount(new UserAccount() { FirstName = "Johnathan", LastName = "Lane", EmailAddress = "john@ogsys.com" });
			Repository.AddUserAccount(new UserAccount() { FirstName = "Jorge", LastName = "Mendez", EmailAddress = "jorge@ogsys.com" });
			Repository.AddUserAccount(new UserAccount() { FirstName = "Jade", LastName = "Fire", EmailAddress = "jade@ogsys.com" });

			var random = new Random();
			var customers = Repository.GetAllCustomerIds();
			var users =  Repository.GetAllUserAccounts();

			#region Long Lorum ipsum
			var noteText = @"
					Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus vehicula finibus dignissim. Curabitur porta luctus tristique. Nunc condimentum suscipit augue, quis feugiat tellus pretium condimentum. Mauris non dui non ex commodo volutpat. In molestie tortor id lorem sollicitudin convallis. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus congue scelerisque elit quis malesuada. Pellentesque auctor, ipsum vel mattis pharetra, nulla mi pretium leo, at maximus augue mauris in arcu.

Maecenas vel velit lorem. Cras pharetra turpis sed metus sollicitudin, a fringilla eros feugiat. Sed sodales turpis non odio faucibus, eget ullamcorper urna vulputate. Quisque accumsan porttitor dui eget elementum. Morbi eget nunc vitae justo mollis consectetur a non diam. Vivamus elit sapien, dignissim ut condimentum at, blandit id odio. Vivamus suscipit nulla at rhoncus scelerisque. Suspendisse ultrices augue odio. Vestibulum non neque massa.
";
			#endregion

			foreach (var customerId in customers)
			{
				var numNotes = random.Next(1, 5);
				for (int i = 1; i <= numNotes; i++)
				{
					int userIndex = random.Next(0, users.Count - 1);
					var user = users[userIndex];
					Note note = new Note() { Body = noteText, CustomerId = customerId, CreatedByUserName = $"{user.FirstName} {user.LastName}" };
					Repository.AddNote(note);
				}
			}
			return RedirectToAction(nameof(HomeController.Index));
		}

		public  ActionResult PerformEmpty()
		{
			foreach (var id in Repository.GetAllCustomerIds())
			{
				Repository.DeleteCustomer(id);
			}

			foreach (var id in Repository.GetAllUserAccountIds())
			{
				Repository.DeleteUserAccount(id);
			}

			foreach (var note in Repository.GetAllNotes())
			{
				Repository.DeleteNote(note.Id);
			}

			return RedirectToAction(nameof(HomeController.Index));
		}
	}
}