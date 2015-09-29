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
	public class UserAccountController : Controller
	{
		private readonly IOgCRMRepository Repository;

		public UserAccountController(IOgCRMRepository repository)
		{
			Repository = repository;
		}

		public ActionResult Index()
		{
			return View(Repository.GetAllUserAccounts());
		}

		public ActionResult New()
		{
			return View();
		}

		public ActionResult Create(UserAccount account)
		{
			Repository.AddUserAccount(account);
			return RedirectToAction(nameof(UserAccountController.Index));
		}

		[AllowAnonymous]
		public ActionResult Login()
		{
			return View();
		}

		[AllowAnonymous]
		public ActionResult Register()
		{
			return View();
		}

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
				return View();
			}
		}

		[AllowAnonymous]
		[HttpPost]
		public ActionResult Register(UserAccount account)
		{
			Repository.AddUserAccount(account);
			return RedirectToAction(nameof(UserAccountController.Login));
		}

		public ActionResult PerformLogout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction(nameof(UserAccountController.Login));
		}
	}
}