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
	public class NotesController : ApiController
	{

		private readonly IOgCRMRepository Repository;

		public NotesController(IOgCRMRepository repository)
		{
			Repository = repository;
		}

		/// <summary>
		/// Returns all notes for a specific customer.
		/// </summary>
		/// <param name="id">The Id of the CUSTOMER to retrieve notes for.</param>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<Note> Get(int id)
		{
			return Repository.GetAllNotes(c => c.CustomerId == id);
		}

		[HttpPost]
		public void Post([FromBody]Note note)
		{
			var user = Repository.GetAllUserAccounts(u => u.EmailAddress.ToLower() == User.Identity.Name.ToLower()).First();
			var name = user.FirstName + " " + user.LastName;
			var hasName = (user.FirstName + user.LastName).Length > 0 ? true : false;
			note.CreatedByUserName = hasName ? name : "User " + user.Id;
			Repository.AddNote(note);
		}

		[HttpDelete]
		public void Delete(int id)
		{
			Repository.DeleteNote(id);
		}
	}
}