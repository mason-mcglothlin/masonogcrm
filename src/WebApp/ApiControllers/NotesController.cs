using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MasonOgCRM.DataAccess.Common;
using MasonOgCRM.DomainModels;

namespace MasonOgCRM.WebApp.ApiControllers
{
	/// <summary>
	/// Provides a REST-based API for interacting with customer notes programtically.
	/// </summary>
	public class NotesController : ApiController
	{
		private readonly IOgCRMRepository Repository;

		/// <summary>
		/// Create an instance of the Notes ApiController.
		/// </summary>
		/// <param name="repository">The repository that provides CRUD of the entities.</param>
		public NotesController(IOgCRMRepository repository)
		{
			Repository = repository;
		}

		/// <summary>
		/// Returns all notes for a specific customer.
		/// </summary>
		/// <param name="id">The Id of the CUSTOMER to retrieve notes for.</param>
		/// <returns>A collection of notes associated with the customer.</returns>
		[HttpGet]
		public IEnumerable<Note> Get(int id)
		{
			return Repository.GetAllNotes(c => c.CustomerId == id);
		}

		/// <summary>
		/// Add a new note to the repository.
		/// </summary>
		/// <param name="note">Note to add to the repository.</param>
		[HttpPost]
		public void Post([FromBody]Note note)
		{
			var user = Repository.GetAllUserAccounts(u => u.EmailAddress.ToLower() == User.Identity.Name.ToLower()).First();
			var name = user.FirstName + " " + user.LastName;
			var hasName = (user.FirstName + user.LastName).Length > 0 ? true : false;
			note.CreatedByUserName = hasName ? name : "User " + user.Id;
			Repository.AddNote(note);
		}

		/// <summary>
		/// Remove a note from the repository.
		/// </summary>
		/// <param name="id">Id of the note to remote from the repository.</param>
		[HttpDelete]
		public void Delete(int id)
		{
			Repository.DeleteNote(id);
		}
	}
}