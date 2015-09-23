using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasonOgCRM.DomainModels
{
	/// <summary>
	/// Represents a single user account for login.
	/// </summary>
	public class UserAccount
	{
		/// <summary>
		/// First name of the user.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Last name of the user.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Email address of the user. Servers as their username.
		/// </summary>
		public string EmailAddress { get; set; }
	}
}
