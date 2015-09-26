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

		public int GetCustomerTotalCount()
		{
			return Customers.Count;
		}

		public Task AddCustomerAsync(Customer customer)
		{
			customer.Id = randomNumberGenerator.Next();
			Customers.Add(customer.Id, customer);
			return Task.FromResult(0);
		}

		public Task AddNoteAsync(Note note)
		{
			note.Id = randomNumberGenerator.Next();
			Notes.Add(note.Id, note);
			return Task.FromResult(0);
		}

		public Task AddUserAccountAsync(UserAccount userAccount)
		{
			userAccount.Id = randomNumberGenerator.Next();
			UserAccounts.Add(userAccount.Id, userAccount);
			return Task.FromResult(0);
		}

		public Task DeleteCustomerAsync(int id)
		{
			Customers.Remove(id);
			return Task.FromResult(0);
		}

		public Task DeleteNoteAsync(int id)
		{
			Notes.Remove(id);
			return Task.FromResult(0);
		}

		public Task DeleteUserAccountAsync(int id)
		{
			UserAccounts.Remove(id);
			return Task.FromResult(0);
		}

		public Task<Customer> FindCustomerByIdAsync(int id)
		{
			var t = new Task<Customer>(() => Customers[id]);
			t.Start();
			return t;
		}

		public Customer FindCustomerById(int id)
		{
			return Customers[id];
		}

		public Task<Note> FindNoteByIdAsync(int id)
		{
			var t = new Task<Note>(() => Notes[id]);
			t.Start();
			return t;
		}

		public Task<UserAccount> FindUserAccountByIdAsync(int id)
		{
			var t = new Task<UserAccount>(() => UserAccounts[id]);
			t.Start();
			return t;
		}

		public Task<List<Customer>> GetAllCustomersAsync()
		{
			var t = new Task<List<Customer>>(() => Customers.Values.ToList());
			t.Start();
			return t;
		}

		public Task<List<Customer>> GetAllCustomersAsync(Expression<Func<Customer, bool>> expression)
		{
			var t = new Task<List<Customer>>( () => Customers.Values.AsQueryable().Where(expression).ToList());
			t.Start();
			return t;
		}

		public Task<List<Note>> GetAllNotesAsync()
		{
			var t = new Task<List<Note>>(() => Notes.Values.ToList());
			t.Start();
			return t;
		}

		public Task<List<Note>> GetAllNotesAsync(Expression<Func<Note, bool>> expression)
		{
			var t = new Task<List<Note>>(() => Notes.Values.AsQueryable().Where(expression).ToList());
			t.Start();
			return t;
		}

		public Task<List<UserAccount>> GetAllUserAccountsAsync()
		{			
			var t = new Task<List<UserAccount>>(() => UserAccounts.Values.ToList());
			t.Start();
			return t;
		}

		public Task<List<UserAccount>> GetAllUserAccountsAsync(Expression<Func<UserAccount, bool>> expression)
		{
			var t = new Task<List<UserAccount>>(() => UserAccounts.Values.AsQueryable().Where(expression).ToList());
			t.Start();
			return t;
		}

		public Task UpdateCustomerAsync(Customer customer)
		{
			Customers[customer.Id] = customer;
			return Task.FromResult(0);
		}

		public Task UpdateNoteAsync(Note note)
		{
			Notes[note.Id] = note;
			return Task.FromResult(0);
		}

		public Task UpdateUserAccountAsync(UserAccount userAccount)
		{
			UserAccounts[userAccount.Id] = userAccount;
			return Task.FromResult(0);
		}
	}
}
