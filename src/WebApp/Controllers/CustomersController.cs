using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MasonOgCRM.DataAccess.Common;

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
    }
}