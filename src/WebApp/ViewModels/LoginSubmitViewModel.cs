using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasonOgCRM.WebApp.ViewModels
{
	/// <summary>
	/// View model representing the username and password submitted by the user.
	/// </summary>
	public class LoginSubmitViewModel
	{
		public string EmailAddress { get; set; }
		public string Password { get; set; }
	}
}
