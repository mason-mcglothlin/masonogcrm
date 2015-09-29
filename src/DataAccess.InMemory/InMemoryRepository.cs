using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MasonOgCRM.DataAccess.Common;
using MasonOgCRM.DomainModels;

namespace MasonOgCRM.DataAccess.InMemory
{
	public class InMemoryRepository : IOgCRMRepository
	{
		private Dictionary<int, Customer> Customers { get; } = new Dictionary<int, Customer>();

		private Dictionary<int, Note> Notes { get; } = new Dictionary<int, Note>();

		private Dictionary<int, UserAccount> UserAccounts { get; } = new Dictionary<int, UserAccount>();

		private Random randomNumberGenerator { get; } = new Random(Int32.MaxValue);

		private readonly IPasswordHasher PasswordService;

		public InMemoryRepository(IPasswordHasher passwordHasher)
		{
			PasswordService = passwordHasher;
		}

		public int GetCustomerTotalCount()
		{
			return Customers.Count;
		}

		public void AddCustomer(Customer customer)
		{
			customer.Id = randomNumberGenerator.Next();
			Customers.Add(customer.Id, customer);
		}

		public void AddNote(Note note)
		{
			note.Id = randomNumberGenerator.Next();
			Notes.Add(note.Id, note);
		}

		public List<int> GetAllCustomerIds()
		{
			return Customers.Keys.ToList();
		}

		public List<int> GetAllUserAccountIds()
		{
			return UserAccounts.Keys.ToList();
		}

		public void AddUserAccount(UserAccount userAccount)
		{
			userAccount.Password = PasswordService.CreateHash(userAccount.Password);
			userAccount.Id = randomNumberGenerator.Next();
			UserAccounts.Add(userAccount.Id, userAccount);
		}

		public void DeleteCustomer(int id)
		{
			Customers.Remove(id);
		}

		public void DeleteNote(int id)
		{
			Notes.Remove(id);
		}

		public void DeleteUserAccount(int id)
		{
			UserAccounts.Remove(id);
		}

		public Customer FindCustomerById(int id)
		{
			return Customers[id];
		}

		public Note FindNoteById(int id)
		{
			return Notes[id];
		}

		public UserAccount FindUserAccountById(int id)
		{
			return UserAccounts[id];
		}

		public List<Customer> GetAllCustomers()
		{
			return Customers.Values.ToList();
		}

		public List<Customer> GetAllCustomers(Expression<Func<Customer, bool>> expression)
		{
			return Customers.Values.AsQueryable().Where(expression).ToList();
		}

		public List<Note> GetAllNotes()
		{
			return Notes.Values.ToList();
		}

		public List<Note> GetAllNotes(Expression<Func<Note, bool>> expression)
		{
			return Notes.Values.AsQueryable().Where(expression).ToList();
		}

		public List<UserAccount> GetAllUserAccounts()
		{
			return UserAccounts.Values.ToList();
		}

		public List<UserAccount> GetAllUserAccounts(Expression<Func<UserAccount, bool>> expression)
		{
			return UserAccounts.Values.AsQueryable().Where(expression).ToList();
		}

		public void UpdateCustomer(Customer customer)
		{
			Customers[customer.Id] = customer;
		}

		public void UpdateNote(Note note)
		{
			Notes[note.Id] = note;
		}

		public void UpdateUserAccount(UserAccount userAccount)
		{
			if (String.IsNullOrEmpty(userAccount.Password))
			{
				//assume password is not being changed, pull the current hash from the db
				var account = FindUserAccountById(userAccount.Id);
				userAccount.Password = account.Password;
			}
			else
			{
				//assume password is being changed
				userAccount.Password = PasswordService.CreateHash(userAccount.Password);
			}
			UserAccounts[userAccount.Id] = userAccount;
		}

		public int GetUserAccountTotalCount()
		{
			return UserAccounts.Count;
		}

		/// <summary>
		/// Authenticate a user against a user account in the database.
		/// </summary>
		/// <param name="username">The username to authenticate against.</param>
		/// <param name="password">The password to authenticate against.</param>
		/// <returns>True if the authentication succeeds, otherwise false.</returns>
		public bool AuthenticateUser(string emailAddress, string password)
		{
			if (UserAccounts.Where(kvp => kvp.Value.EmailAddress == emailAddress).Count() > 0)
			{
				var correctHash = UserAccounts.Where(kvp => kvp.Value.EmailAddress == emailAddress).First().Value.Password;
				return PasswordService.ValidatePassword(password, correctHash);
			}
			else
			{
				return false;
			}
		}

	}
}
