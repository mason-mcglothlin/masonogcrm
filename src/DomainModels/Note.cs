using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasonOgCRM.DomainModels
{
	/// <summary>
	/// A note about a customer. There is a one to many relationship between customer and notes.
	/// </summary>
	public class Note
	{
		/// <summary>
		/// Unique Id to identify the Note.
		/// </summary>
		[DisplayName("Id")]
		public int Id { get; set; }

		/// <summary>
		/// The main body of the note (text).
		/// </summary>
		[DisplayName("Body")]
		public string Body { get; set; }

		/// <summary>
		/// This is the user that created the note.
		/// </summary>
		[DisplayName("Created By")]
		public string CreatedByUserId { get; set; }

		/// <summary>
		/// This is the customer that the note is for.
		/// </summary>
		[DisplayName("Customer Id")]
		public string CustomerId { get; set; }
	}
}
