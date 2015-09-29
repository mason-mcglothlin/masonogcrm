using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasonOgCRM.WebApp.ViewModels
{
	/// <summary>
	/// Model for communicating information about a login attempt back to the user.
	/// </summary>
	public class LoginAttemptViewModel
	{
		public string Message { get; set; }
	}
}
