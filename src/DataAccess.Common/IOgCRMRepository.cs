using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MasonOgCRM.DomainModels;

namespace MasonOgCRM.DataAccess.Common
{
	/// <summary>
	/// Interface that defines the functions an OgCRM repository should implement for CRUD of domain entities.
	/// </summary>
	public interface IOgCRMRepository
	{
		/// <summary>
		/// Retrieve a Customer from the repository by Id.
		/// </summary>
		/// <param name="id">Id of the customer to retrieve.</param>
		/// <returns></returns>
		Task<Customer> FindCustomerByIdAsync(int id);

		/// <summary>
		/// Retrieve all Customer objects from the repository.
		/// </summary>
		/// <returns></returns>
		Task<List<Customer>> GetAllCustomersAsync();

		/// <summary>
		/// Retrieve all Customer objects from the repostory that match the given expression.
		/// </summary>
		/// <param name="expression">Expression that returns true for Customer objects to retrieve.</param>
		/// <returns></returns>
		Task<List<Customer>> GetAllCustomersAsync(Expression<Func<Customer, bool>> expression);

		/// <summary>
		/// Remove a customer from the repository.
		/// </summary>
		/// <param name="id">Id of the customer to remove from the repository.</param>
		/// <returns></returns>
		Task DeleteCustomerAsync(int id);

		/// <summary>
		/// Update a Customer in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="customer">Customer object that contains the modified property values to update with.</param>
		/// <returns></returns>
		Task UpdateCustomerAsync(Customer customer);

		/// <summary>
		/// Add a customer to the repository.
		/// </summary>
		/// <param name="customer">Customer object to add to the repository.</param>
		/// <returns></returns>
		Task AddCustomerAsync(Customer customer);

		/// <summary>
		/// Retrieve a UserAccount from the repository by Id.
		/// </summary>
		/// <param name="id">Id of the UserAccount to retrieve.</param>
		/// <returns></returns>
		Task<UserAccount> FindUserAccountByIdAsync(int id);

		/// <summary>
		/// Retrieve all UserAccount objects from the repository.
		/// </summary>
		/// <returns></returns>
		Task<List<UserAccount>> GetAllUserAccountsAsync();

		/// <summary>
		/// Retrieve all UserAccount objects from the repository that match the given expression.
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		Task<List<UserAccount>> GetAllUserAccountsAsync(Expression<Func<UserAccount, bool>> expression);

		/// <summary>
		/// Remove a user account from the repository.
		/// </summary>
		/// <param name="id">Id of the user account to remove from the repository.</param>
		/// <returns></returns>
		Task DeleteUserAccountAsync(int id);

		/// <summary>
		/// Update a UserAccount in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="userAccount">UserAccoubt object that contains the modified property values to update with.</param>
		/// <returns></returns>
		Task UpdateUserAccountAsync(UserAccount userAccount);

		/// <summary>
		/// Add a user account to the repository.
		/// </summary>
		/// <param name="userAccount">UserAccount to add to the repository.</param>
		/// <returns></returns>
		Task AddUserAccountAsync(UserAccount userAccount);

		/// <summary>
		/// Retrieve a Note from the repository by Id.
		/// </summary>
		/// <param name="id">Id of the note to retrieve.</param>
		/// <returns></returns>
		Task<Note> FindNoteByIdAsync(int id);

		/// <summary>
		/// Retrieve all Note objects from the repository.
		/// </summary>
		/// <returns></returns>
		Task<List<Note>> GetAllNotesAsync();

		/// <summary>
		/// Retrieve all Note objects from the repository that match the given expression.
		/// </summary>
		/// <param name="expression">Expression that returns true for Customer objects to retrieve.</param>
		/// <returns></returns>
		Task<List<Note>> GetAllNotesAsync(Expression<Func<Note, bool>> expression);

		/// <summary>
		/// Remove a note from the repository.
		/// </summary>
		/// <param name="id">Id of the note to remove from the repository.</param>
		/// <returns></returns>
		Task DeleteNoteAsync(int id);

		/// <summary>
		/// Update a Note in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="note">Note object that contains the modified property values to update with.</param>
		/// <returns></returns>
		Task UpdateNoteAsync(Note note);

		/// <summary>
		/// Add a note to the repository.
		/// </summary>
		/// <param name="userAccount">Note to add the repository.</param>
		/// <returns></returns>
		Task AddNoteAsync(Note note);
	}
}
