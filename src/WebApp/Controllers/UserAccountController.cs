using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MasonOgCRM.DataAccess.Common;
using MasonOgCRM.DomainModels;
using MasonOgCRM.WebApp.Helpers;
using MasonOgCRM.WebApp.ViewModels;

namespace MasonOgCRM.WebApp.Controllers
{
	/// <summary>
	/// Controller for manipulating UserAccount objects.
	/// </summary>
	public class UserAccountController : Controller
	{
		private readonly IOgCRMRepository Repository;

		/// <summary>
		/// Create an instance of this controller with the necessary dependencies.
		/// </summary>
		/// <param name="repository">Repository to perform CRUD of user accounts against.</param>
		public UserAccountController(IOgCRMRepository repository)
		{
			Repository = repository;
		}

		/// <summary>
		/// List all user accounts in the repository.
		/// </summary>
		/// <returns>View with a collection of all user accounts in the repository.</returns>
		public ActionResult Index()
		{
			return View(Repository.GetAllUserAccounts());
		}

		/// <summary>
		/// Page for creating a new user account in the repository.
		/// </summary>
		/// <returns>View for creating a new user account.</returns>
		public ActionResult New()
		{
			return View();
		}

		/// <summary>
		/// Action method to post against that creates a new user account in the database.
		/// </summary>
		/// <param name="account">An object representing a new user account to add to the repository.</param>
		/// <returns>A redirect back to the Index page.</returns>
		public ActionResult Create(UserAccount account)
		{
			Repository.AddUserAccount(account);
			return RedirectToAction(nameof(UserAccountController.Index));
		}

		/// <summary>
		/// Login page for authenticating to the application.
		/// </summary>
		/// <returns>A page for logging into the application.</returns>
		[AllowAnonymous]
		public ActionResult Login()
		{
			return View(new LoginAttemptViewModel());
		}

		/// <summary>
		/// Registration page for creating a new user account in the application, for users that do not already have an account.
		/// </summary>
		/// <returns>Page for creating a new user account.</returns>
		[AllowAnonymous]
		public ActionResult Register()
		{
			return View();
		}

		/// <summary>
		/// Action method to post login page submissions against.
		/// </summary>
		/// <param name="loginViewModel">View model containing the username and password to login with.</param>
		/// <param name="returnUrl">Page to redirect the user to upon successful login, can be empty.</param>
		/// <returns>The application home page if login is successful, otherwise the login page with a message that authentication did not succeed.</returns>
		[AllowAnonymous]
		[HttpPost]
		public ActionResult Login(LoginSubmitViewModel loginViewModel, string returnUrl)
		{
			bool success = Repository.AuthenticateUser(loginViewModel.EmailAddress, loginViewModel.Password);
			if (success)
			{
				FormsAuthentication.SetAuthCookie(loginViewModel.EmailAddress, false);
				return Redirect(returnUrl ?? Url.Action(nameof(HomeController.Index), nameof(HomeController).RemoveControllerFromName()));
			}
			else
			{
				return View(new LoginAttemptViewModel() { Message = "Username or password invalid" });
			}
		}

		/// <summary>
		/// Action method to post new registration submissions against.
		/// </summary>
		/// <param name="account">Model representing the new user account to create.</param>
		/// <returns>Returns a view representing successful account registration.</returns>
		[AllowAnonymous]
		[HttpPost]
		public ActionResult Register(UserAccount account)
		{
			Repository.AddUserAccount(account);
			return View("RegistrationSuccess");
		}

		/// <summary>
		/// Action to log out of the application.
		/// </summary>
		/// <returns>A redirect to the application login page.</returns>
		public ActionResult PerformLogout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction(nameof(UserAccountController.Login));
		}
	}
}