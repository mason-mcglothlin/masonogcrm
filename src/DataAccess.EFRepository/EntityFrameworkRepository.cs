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

		/// <summary>
		/// Create a new EntityFrameworkRepository with a connection string.
		/// </summary>
		/// <param name="connectionString">Connection string to use to initialize the Entity Framework context.</param>
		public EntityFrameworkRepository(IDbContext context)
		{
			DBContext = context;
        }

		/// <summary>
		/// Add a customer to the repository.
		/// </summary>
		/// <param name="customer">Customer object to add to the repository.</param>
		/// <returns></returns>
		public async Task AddCustomerAsync(Customer customer)
		{
			DBContext.Customers.Add(customer);
			await DBContext.SaveChangesAsync();
		}

		/// <summary>
		/// Add a note to the repository.
		/// </summary>
		/// <param name="userAccount">Note to add the repository.</param>
		/// <returns></returns>
		public async Task AddNoteAsync(Note note)
		{
			DBContext.Notes.Add(note);
			await DBContext.SaveChangesAsync();
		}

		/// <summary>
		/// Add a user account to the repository.
		/// </summary>
		/// <param name="userAccount">UserAccount to add to the repository.</param>
		/// <returns></returns>
		public async Task AddUserAccountAsync(UserAccount userAccount)
		{
			DBContext.UserAccounts.Add(userAccount);
			await DBContext.SaveChangesAsync();
		}

		/// <summary>
		/// Remove a customer from the repository.
		/// </summary>
		/// <param name="id">Id of the customer to remove from the repository.</param>
		/// <returns></returns>
		public async Task DeleteCustomerAsync(int id)
		{
			var customer = await FindCustomerByIdAsync(id);
			DBContext.Entry(customer).State = EntityState.Deleted;
			await DBContext.SaveChangesAsync();
		}

		/// <summary>
		/// Remove a note from the repository.
		/// </summary>
		/// <param name="id">Id of the note to remove from the repository.</param>
		/// <returns></returns>
		public async Task DeleteNoteAsync(int id)
		{
			var note = await FindNoteByIdAsync(id);
			DBContext.Entry(note).State = EntityState.Deleted;
			await DBContext.SaveChangesAsync();
		}

		/// <summary>
		/// Remove a user account from the repository.
		/// </summary>
		/// <param name="id">Id of the user account to remove from the repository.</param>
		/// <returns></returns>
		public async Task DeleteUserAccountAsync(int id)
		{
			var userAccount = await FindUserAccountByIdAsync(id);
			DBContext.Entry(userAccount).State = EntityState.Deleted;
			await DBContext.SaveChangesAsync();
		}

		/// <summary>
		/// Retrieve a Customer from the repository by Id asynchronously.
		/// </summary>
		/// <param name="id">Id of the customer to retrieve.</param>
		/// <returns></returns>
		public async Task<Customer> FindCustomerByIdAsync(int id)
		{
			return await DBContext.Customers.Where(customer => customer.Id == id).SingleAsync();
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
		public async Task<Note> FindNoteByIdAsync(int id)
		{
			return await DBContext.Notes.Where(note => note.Id == id).SingleAsync();
		}

		/// <summary>
		/// Retrieve a UserAccount from the repository by Id.
		/// </summary>
		/// <param name="id">Id of the UserAccount to retrieve.</param>
		/// <returns></returns>
		public async Task<UserAccount> FindUserAccountByIdAsync(int id)
		{
			return await DBContext.UserAccounts.Where(userAccount => userAccount.Id == id).SingleAsync();
		}

		/// <summary>
		/// Retrieve all Customer objects from the repostory that match the given expression.
		/// </summary>
		/// <param name="expression">Expression that returns true for Customer objects to retrieve.</param>
		/// <returns></returns>
		public async Task<List<Customer>> GetAllCustomersAsync(Expression<Func<Customer, bool>> expression)
		{
			return await DBContext.Customers.Where(expression).ToListAsync();
		}

		/// <summary>
		/// Retrieve all Customer objects from the repository.
		/// </summary>
		/// <returns></returns>
		public async Task<List<Customer>> GetAllCustomersAsync()
		{
			return await DBContext.Customers.ToListAsync();
		}

		/// <summary>
		/// Retrieve all Note objects from the repository that match the given expression.
		/// </summary>
		/// <param name="expression">Expression that returns true for Customer objects to retrieve.</param>
		/// <returns></returns>
		public async Task<List<Note>> GetAllNotesAsync(Expression<Func<Note, bool>> expression)
		{
			return await DBContext.Notes.Where(expression).ToListAsync();
		}

		/// <summary>
		/// Retrieve all Note objects from the repository.
		/// </summary>
		/// <returns></returns>
		public async Task<List<Note>> GetAllNotesAsync()
		{
			return await DBContext.Notes.ToListAsync();
		}

		/// <summary>
		/// Retrieve all UserAccount objects from the repository that match the given expression.
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public async Task<List<UserAccount>> GetAllUserAccountsAsync(Expression<Func<UserAccount, bool>> expression)
		{
			return await DBContext.UserAccounts.Where(expression).ToListAsync();
		}

		/// <summary>
		/// Retrieve all UserAccount objects from the repository.
		/// </summary>
		/// <returns></returns>
		public async Task<List<UserAccount>> GetAllUserAccountsAsync()
		{
			return await DBContext.UserAccounts.ToListAsync();
		}

		/// <summary>
		/// Update a Customer in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="customer">Customer object that contains the modified property values to update with.</param>
		/// <returns></returns>
		public async Task UpdateCustomerAsync(Customer customer)
		{
			DBContext.Customers.AddOrUpdate(customer);
			await DBContext.SaveChangesAsync();
		}

		/// <summary>
		/// Update a Note in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="note">Note object that contains the modified property values to update with.</param>
		/// <returns></returns>
		public async Task UpdateNoteAsync(Note note)
		{
			DBContext.Notes.AddOrUpdate(note);
			await DBContext.SaveChangesAsync();
		}

		/// <summary>
		/// Update a UserAccount in the repository that has the matching Id with modified property values.
		/// </summary>
		/// <param name="userAccount">UserAccoubt object that contains the modified property values to update with.</param>
		/// <returns></returns>
		public async Task UpdateUserAccountAsync(UserAccount userAccount)
		{
			DBContext.UserAccounts.AddOrUpdate(userAccount);
			await DBContext.SaveChangesAsync();
		}
	}
}
