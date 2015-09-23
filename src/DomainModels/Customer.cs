﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
	/// <summary>
	/// Represents a customer, the main data in the application.
	/// </summary>
	public class Customer
	{
		/// <summary>
		/// First name of the customer.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Last name of the customer.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// The name of the company that the customer works for.
		/// </summary>
		public string CompanyName { get; set; }

		/// <summary>
		/// The email address of the customer.
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// The physical address of the customer.
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// The phone number of the customer.
		/// </summary>
		public string PhoneNumber { get; set; }
	}
}
