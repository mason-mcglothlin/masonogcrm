using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasonOgCRM.WebApp.ViewModels
{
	/// <summary>
	/// Defines information needed by the Layout shared view to render itself.
	/// </summary>
	public class LayoutViewModel
	{
		public int NumberOfCustomers { get; set; }
		public int NumberOfUserAccounts { get; set; }
	}
}
