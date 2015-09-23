using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
	/// <summary>
	/// A note about a customer. There is a one to many relationship between customer and notes.
	/// </summary>
	public class Note
	{
		/// <summary>
		/// The main body of the note (text).
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// This is the user that created the note.
		/// </summary>
		public string CreatedByUser { get; set; }
	}
}
