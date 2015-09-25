using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasonOgCRM.DomainModels
{
	/// <summary>
	/// Represents a customer, the main data in the application.
	/// </summary>
	public class Customer
	{

		/// <summary>
		/// Unique Id to identify the customer.
		/// </summary>
		[DisplayName("Id")]
		public int Id {get; set;}

		/// <summary>
		/// First name of the customer.
		/// </summary>
		[DisplayName("First Name")]
		public string FirstName { get; set; }

		/// <summary>
		/// Last name of the customer.
		/// </summary>
		[DisplayName("Last Name")]
		public string LastName { get; set; }

		/// <summary>
		/// The name of the company that the customer works for.
		/// </summary>
		[DisplayName("Company")]
		public string CompanyName { get; set; }

		/// <summary>
		/// The email address of the customer.
		/// </summary>
		[DisplayName("Email Address")]
		public string EmailAddress { get; set; }

		/// <summary>
		/// The physical address of the customer.
		/// </summary>
		[DisplayName("Address")]
		public string Address { get; set; }

		/// <summary>
		/// The phone number of the customer.
		/// </summary>
		[DisplayName("Phone Number")]
		public string PhoneNumber { get; set; }
	}
}
