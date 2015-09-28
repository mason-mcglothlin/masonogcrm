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

		public ActionResult Login()
		{
			return View();
		}
	}
}