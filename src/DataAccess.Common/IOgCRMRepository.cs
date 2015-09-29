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
		Customer FindCustomerById(int id);

		/// <summary>
		/// Retrieves the total number of customers from the database.
		/// </summary>
		/// <returns></returns>
		int GetCustomerTotalCount();

		/// <summary>
		/// Retrieve all Customer objects from the repository.
		/// </summary>
		/// <returns></returns>
		List<Customer> GetAllCustomers();

		/// <summary>
		/// Get all customer Id's from the database.
		/// </summary>
		/// <returns></returns>
		List<int> GetAllCustomerIds();

		/// <summary>
		/// Retrieve all Customer objects from the repostory that match the given expression.
		/// </summary>
		/// <param name="expression">Expression that returns true for Customer objects to retrieve.</param>
		/// <returns></returns>
		List<Customer> GetAllCustomers(Expression<Func<Customer, bool>> expression);

		/// <summary>
		/// Remove a customer from the repository.
		/// </summary>
		/// <param name="id">Id of the customer to remove from the repository.</param>
		/// <returns></returns>
		void DeleteCustomer(int id);

		/// <summary>
		/// Update a Customer in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="customer">Customer object that contains the modified property values to update with.</param>
		/// <returns></returns>
		void UpdateCustomer(Customer customer);

		/// <summary>
		/// Add a customer to the repository.
		/// </summary>
		/// <param name="customer">Customer object to add to the repository.</param>
		/// <returns></returns>
		void AddCustomer(Customer customer);

		/// <summary>
		/// Retrieve a UserAccount from the repository by Id.
		/// </summary>
		/// <param name="id">Id of the UserAccount to retrieve.</param>
		/// <returns></returns>
		UserAccount FindUserAccountById(int id);

		/// <summary>
		/// Retrieve all UserAccount objects from the repository.
		/// </summary>
		/// <returns></returns>
		List<UserAccount> GetAllUserAccounts();

		/// <summary>
		/// Retrieve all UserAccount objects from the repository that match the given expression.
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		List<UserAccount> GetAllUserAccounts(Expression<Func<UserAccount, bool>> expression);

		/// <summary>
		/// Remove a user account from the repository.
		/// </summary>
		/// <param name="id">Id of the user account to remove from the repository.</param>
		/// <returns></returns>
		void DeleteUserAccount(int id);

		/// <summary>
		/// Update a UserAccount in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="userAccount">UserAccoubt object that contains the modified property values to update with.</param>
		/// <returns></returns>
		void UpdateUserAccount(UserAccount userAccount);

		/// <summary>
		/// Add a user account to the repository.
		/// </summary>
		/// <param name="userAccount">UserAccount to add to the repository.</param>
		/// <returns></returns>
		void AddUserAccount(UserAccount userAccount);

		/// <summary>
		/// Get all User Account Id's from the database.
		/// </summary>
		/// <returns></returns>
		List<int> GetAllUserAccountIds();

		/// <summary>
		/// Returns the total number of user accounts in the database.
		/// </summary>
		/// <returns></returns>
		int GetUserAccountTotalCount();

		/// <summary>
		/// Retrieve a Note from the repository by Id.
		/// </summary>
		/// <param name="id">Id of the note to retrieve.</param>
		/// <returns></returns>
		Note FindNoteById(int id);

		/// <summary>
		/// Retrieve all Note objects from the repository.
		/// </summary>
		/// <returns></returns>
		List<Note> GetAllNotes();

		/// <summary>
		/// Retrieve all Note objects from the repository that match the given expression.
		/// </summary>
		/// <param name="expression">Expression that returns true for Customer objects to retrieve.</param>
		/// <returns></returns>
		List<Note> GetAllNotes(Expression<Func<Note, bool>> expression);

		/// <summary>
		/// Remove a note from the repository.
		/// </summary>
		/// <param name="id">Id of the note to remove from the repository.</param>
		/// <returns></returns>
		void DeleteNote(int id);

		/// <summary>
		/// Update a Note in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="note">Note object that contains the modified property values to update with.</param>
		/// <returns></returns>
		void UpdateNote(Note note);

		/// <summary>
		/// Add a note to the repository.
		/// </summary>
		/// <param name="userAccount">Note to add the repository.</param>
		/// <returns></returns>
		void AddNote(Note note);

		/// <summary>
		/// Authenticate a user against a user account in the database.
		/// </summary>
		/// <param name="username">The username to authenticate against.</param>
		/// <param name="password">The password to authenticate against.</param>
		/// <returns>True if the authentication succeeds, otherwise false.</returns>
		bool AuthenticateUser(string emailAddress, string password);
	}
}
