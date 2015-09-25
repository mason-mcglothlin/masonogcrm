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

		public async Task<ActionResult> Index()
        {			
            return View(await Repository.GetAllUserAccountsAsync());
        }

		public ActionResult New()
		{
			return View();
		}

		public async Task<ActionResult> Create(UserAccount account)
		{
			await Repository.AddUserAccountAsync(account);
			return RedirectToAction(nameof(UserAccountController.Index));
		}

    }
}