using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MasonOgCRM.DataAccess.Common;
using MasonOgCRM.DomainModels;

namespace MasonOgCRM.DataAccess.EFRepository
{
	/// <summary>
	/// Repository class for retriving entities using Entity Framework
	/// </summary>
	public class EntityFrameworkRepository : IOgCRMRepository
	{
		/// <summary>
		/// Add a customer to the repository.
		/// </summary>
		/// <param name="customer">Customer object to add to the repository.</param>
		/// <returns></returns>
		public Task AddCustomerAsync(Customer customer)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Add a note to the repository.
		/// </summary>
		/// <param name="userAccount">Note to add the repository.</param>
		/// <returns></returns>
		public Task AddNoteAsync(Note note)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Add a user account to the repository.
		/// </summary>
		/// <param name="userAccount">UserAccount to add to the repository.</param>
		/// <returns></returns>
		public Task AddUserAccountAsync(UserAccount userAccount)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Remove a customer from the repository.
		/// </summary>
		/// <param name="id">Id of the customer to remove from the repository.</param>
		/// <returns></returns>
		public Task DeleteCustomerAsync(int id)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Remove a note from the repository.
		/// </summary>
		/// <param name="id">Id of the note to remove from the repository.</param>
		/// <returns></returns>
		public Task DeleteNoteAsync(int id)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Remove a user account from the repository.
		/// </summary>
		/// <param name="id">Id of the user account to remove from the repository.</param>
		/// <returns></returns>
		public Task DeleteUserAccountAsync(int id)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieve a Customer from the repository by Id.
		/// </summary>
		/// <param name="id">Id of the customer to retrieve.</param>
		/// <returns></returns>
		public Task<Customer> FindCustomerByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieve a Note from the repository by Id.
		/// </summary>
		/// <param name="id">Id of the note to retrieve.</param>
		/// <returns></returns>
		public Task<Note> FindNoteByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieve a UserAccount from the repository by Id.
		/// </summary>
		/// <param name="id">Id of the UserAccount to retrieve.</param>
		/// <returns></returns>
		public Task<UserAccount> FindUserAccountByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieve all Customer objects from the repostory that match the given expression.
		/// </summary>
		/// <param name="expression">Expression that returns true for Customer objects to retrieve.</param>
		/// <returns></returns>
		public Task<List<Customer>> GetAllCustomersAsync(Expression<Func<bool>> expression)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieve all Customer objects from the repository.
		/// </summary>
		/// <returns></returns>
		public Task<List<Customer>> GetAllCustomersAsync()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieve all Note objects from the repository that match the given expression.
		/// </summary>
		/// <param name="expression">Expression that returns true for Customer objects to retrieve.</param>
		/// <returns></returns>
		public Task<List<Note>> GetAllNotesAsync(Expression<Func<bool>> expression)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieve all Note objects from the repository.
		/// </summary>
		/// <returns></returns>
		public Task<List<Note>> GetAllNotesAsync()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieve all UserAccount objects from the repository that match the given expression.
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public Task<List<UserAccount>> GetAllUserAccountsAsync(Expression<Func<bool>> expression)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieve all UserAccount objects from the repository.
		/// </summary>
		/// <returns></returns>
		public Task<List<UserAccount>> GetAllUserAccountsAsync()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Update a Customer in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="customer">Customer object that contains the modified property values to update with.</param>
		/// <returns></returns>
		public Task UpdateCustomerAsync(Customer customer)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Update a Note in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="note">Note object that contains the modified property values to update with.</param>
		/// <returns></returns>
		public Task UpdateNoteAsync(Note note)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Update a UserAccount in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="userAccount">UserAccoubt object that contains the modified property values to update with.</param>
		/// <returns></returns>
		public Task UpdateUserAccountAsync(UserAccount userAccount)
		{
			throw new NotImplementedException();
		}
	}
}
