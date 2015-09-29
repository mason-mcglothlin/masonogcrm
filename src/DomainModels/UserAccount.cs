using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		/// Unique Id to identify the UserAccount.
		/// </summary>
		[DisplayName("Id")]
		public int Id { get; set; }

		/// <summary>
		/// First name of the user.
		/// </summary>
		[DisplayName("First Name")]
		public string FirstName { get; set; }

		/// <summary>
		/// Last name of the user.
		/// </summary>
		[DisplayName("Last Name")]
		public string LastName { get; set; }

		/// <summary>
		/// Email address of the user. Servers as their username.
		/// </summary>
		[DisplayName("Email Address")]
		public string EmailAddress { get; set; }

		public string Password { get; set; }
	}
}
