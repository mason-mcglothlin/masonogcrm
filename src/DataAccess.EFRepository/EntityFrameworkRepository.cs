using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MasonOgCRM.DataAccess.Common;
using MasonOgCRM.DomainModels;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace MasonOgCRM.DataAccess.EF
{
	/// <summary>
	/// Repository class for retriving entities using Entity Framework
	/// </summary>
	public class EntityFrameworkRepository : IOgCRMRepository
	{
		/// <summary>
		/// Reference to EntityFrameworkRepository initialized in the constructor, used to interact with the database.
		/// </summary>
		private readonly IDbContext DBContext;

		private readonly IPasswordHasher PasswordService;

		/// <summary>
		/// Create a new EntityFrameworkRepository with a connection string.
		/// </summary>
		/// <param name="connectionString">Connection string to use to initialize the Entity Framework context.</param>
		public EntityFrameworkRepository(IDbContext context, IPasswordHasher passwordHasher)
		{
			DBContext = context;
			PasswordService = passwordHasher;
		}

		/// <summary>
		/// Add a customer to the repository.
		/// </summary>
		/// <param name="customer">Customer object to add to the repository.</param>
		/// <returns></returns>
		public void AddCustomer(Customer customer)
		{
			DBContext.Customers.Add(customer);
			DBContext.SaveChanges();
		}

		/// <summary>
		/// Retrieves the total number of customers from the database.
		/// </summary>
		/// <returns></returns>
		public int GetCustomerTotalCount()
		{
			return DBContext.Customers.Count();
		}

		/// <summary>
		/// Get all customer Id's from the database.
		/// </summary>
		/// <returns></returns>
		public List<int> GetAllCustomerIds()
		{
			return DBContext.Customers.Select(c => c.Id).ToList();
		}

		/// <summary>
		/// Add a note to the repository.
		/// </summary>
		/// <param name="userAccount">Note to add the repository.</param>
		/// <returns></returns>
		public void AddNote(Note note)
		{
			DBContext.Notes.Add(note);
			DBContext.SaveChanges();
		}

		/// <summary>
		/// Add a user account to the repository.
		/// </summary>
		/// <param name="userAccount">UserAccount to add to the repository.</param>
		/// <returns></returns>
		public void AddUserAccount(UserAccount userAccount)
		{
			userAccount.Password = PasswordService.CreateHash(userAccount.Password);
			DBContext.UserAccounts.Add(userAccount);
			DBContext.SaveChanges();
		}

		/// <summary>
		/// Remove a customer from the repository.
		/// </summary>
		/// <param name="id">Id of the customer to remove from the repository.</param>
		/// <returns></returns>
		public void DeleteCustomer(int id)
		{
			var customer = FindCustomerById(id);
			DBContext.SetState(customer, EntityState.Deleted);
			DBContext.SaveChanges();
		}

		/// <summary>
		/// Remove a note from the repository.
		/// </summary>
		/// <param name="id">Id of the note to remove from the repository.</param>
		/// <returns></returns>
		public void DeleteNote(int id)
		{
			var note = FindNoteById(id);
			DBContext.Entry(note).State = EntityState.Deleted;
			DBContext.SaveChanges();
		}

		/// <summary>
		/// Remove a user account from the repository.
		/// </summary>
		/// <param name="id">Id of the user account to remove from the repository.</param>
		/// <returns></returns>
		public void DeleteUserAccount(int id)
		{
			var userAccount = FindUserAccountById(id);
			DBContext.Entry(userAccount).State = EntityState.Deleted;
			DBContext.SaveChanges();
		}

		/// <summary>
		/// Retrieve a Customer from the repository by Id.
		/// </summary>
		/// <param name="id">Id of the customer to retrieve.</param>
		/// <returns></returns>
		public Customer FindCustomerById(int id)
		{
			return DBContext.Customers.Where(customer => customer.Id == id).Single();
		}

		/// <summary>
		/// Retrieve a Note from the repository by Id.
		/// </summary>
		/// <param name="id">Id of the note to retrieve.</param>
		/// <returns></returns>
		public Note FindNoteById(int id)
		{
			return DBContext.Notes.Where(note => note.Id == id).Single();
		}

		/// <summary>
		/// Retrieve a UserAccount from the repository by Id.
		/// </summary>
		/// <param name="id">Id of the UserAccount to retrieve.</param>
		/// <returns></returns>
		public UserAccount FindUserAccountById(int id)
		{
			return DBContext.UserAccounts.Where(userAccount => userAccount.Id == id).Single();
		}

		/// <summary>
		/// Retrieve all Customer objects from the repostory that match the given expression.
		/// </summary>
		/// <param name="expression">Expression that returns true for Customer objects to retrieve.</param>
		/// <returns></returns>
		public List<Customer> GetAllCustomers(Expression<Func<Customer, bool>> expression)
		{
			return DBContext.Customers.Where(expression).ToList();
		}

		/// <summary>
		/// Retrieve all Customer objects from the repository.
		/// </summary>
		/// <returns></returns>
		public List<Customer> GetAllCustomers()
		{
			return DBContext.Customers.ToList();
		}

		/// <summary>
		/// Retrieve all Note objects from the repository that match the given expression.
		/// </summary>
		/// <param name="expression">Expression that returns true for Customer objects to retrieve.</param>
		/// <returns></returns>
		public List<Note> GetAllNotes(Expression<Func<Note, bool>> expression)
		{
			return DBContext.Notes.Where(expression).ToList();
		}

		/// <summary>
		/// Retrieve all Note objects from the repository.
		/// </summary>
		/// <returns></returns>
		public List<Note> GetAllNotes()
		{
			return DBContext.Notes.ToList();
		}

		/// <summary>
		/// Retrieve all UserAccount objects from the repository that match the given expression.
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public List<UserAccount> GetAllUserAccounts(Expression<Func<UserAccount, bool>> expression)
		{
			return DBContext.UserAccounts.Where(expression).ToList();
		}

		/// <summary>
		/// Retrieve all UserAccount objects from the repository.
		/// </summary>
		/// <returns></returns>
		public List<UserAccount> GetAllUserAccounts()
		{
			return DBContext.UserAccounts.ToList();
		}

		/// <summary>
		/// Update a Customer in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="customer">Customer object that contains the modified property values to update with.</param>
		/// <returns></returns>
		public void UpdateCustomer(Customer customer)
		{
			DBContext.Customers.AddOrUpdate(customer);
			DBContext.SaveChanges();
		}

		/// <summary>
		/// Update a Note in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="note">Note object that contains the modified property values to update with.</param>
		/// <returns></returns>
		public void UpdateNote(Note note)
		{
			DBContext.Notes.AddOrUpdate(note);
			DBContext.SaveChanges();
		}

		/// <summary>
		/// Update a UserAccount in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="userAccount">UserAccoubt object that contains the modified property values to update with.</param>
		/// <returns></returns>
		public void UpdateUserAccount(UserAccount userAccount)
		{
			if(String.IsNullOrEmpty(userAccount.Password))
			{
				//assume password is not being changed, pull the current hash from the db
				var account = FindUserAccountById(userAccount.Id);
				userAccount.Password = account.Password;
			}
			else {
				//assume password is being changed
				userAccount.Password = PasswordService.CreateHash(userAccount.Password);
			}

			DBContext.UserAccounts.AddOrUpdate(userAccount);
			DBContext.SaveChanges();
		}

		/// <summary>
		/// Returns the total number of user accounts in the database.
		/// </summary>
		/// <returns></returns>
		public int GetUserAccountTotalCount()
		{
			return DBContext.UserAccounts.Count();
		}

		/// <summary>
		/// Get all User Account Id's from the database.
		/// </summary>
		/// <returns></returns>
		public List<int> GetAllUserAccountIds()
		{
			return DBContext.UserAccounts.Select(c => c.Id).ToList();
		}

		/// <summary>
		/// Authenticate a user against a user account in the database.
		/// </summary>
		/// <param name="username">The username to authenticate against.</param>
		/// <param name="password">The password to authenticate against.</param>
		/// <returns>True if the authentication succeeds, otherwise false.</returns>
		public bool AuthenticateUser(string emailAddress, string password)
		{
			var account = DBContext.UserAccounts.Where(ua => ua.EmailAddress == emailAddress).FirstOrDefault();
			if (account == null)
			{
				return false;
			}
			if (PasswordService.ValidatePassword(password, account.Password))
			{
				return true;
			}
			else
			{
				return false;
			}

		}
	}
}
