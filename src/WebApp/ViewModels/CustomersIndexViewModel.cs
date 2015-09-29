using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasonOgCRM.DomainModels;

namespace MasonOgCRM.WebApp.ViewModels
{
	/// <summary>
	/// View model for the customers index page, contains a list of customers.
	/// </summary>
	public class CustomersIndexViewModel
	{
		public List<Customer> AllCustomersList { get; set; }
	}
}
