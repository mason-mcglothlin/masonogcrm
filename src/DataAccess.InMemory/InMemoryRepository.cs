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
		private Dictionary<int, Customer> Customers { get; set; } = new Dictionary<int, Customer>();

		private Dictionary<int, Note> Notes { get; set; } = new Dictionary<int, Note>();

		private Dictionary<int, UserAccount> UserAccounts = new Dictionary<int, UserAccount>();


		public Task AddCustomerAsync(Customer customer)
		{
			Customers.Add(customer.Id, customer);
			return Task.FromResult(0);
		}

		public Task AddNoteAsync(Note note)
		{
			Notes.Add(note.Id, note);
			return Task.FromResult(0);
		}

		public Task AddUserAccountAsync(UserAccount userAccount)
		{
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
			return new Task<Customer>(() => Customers[id]);
		}

		public Task<Note> FindNoteByIdAsync(int id)
		{
			return new Task<Note>(() => Notes[id]);
		}

		public Task<UserAccount> FindUserAccountByIdAsync(int id)
		{
			return new Task<UserAccount>(() => UserAccounts[id]);
		}

		public Task<List<Customer>> GetAllCustomersAsync()
		{
			return new Task<List<Customer>>(() => Customers.Values.ToList());
		}

		public Task<List<Customer>> GetAllCustomersAsync(Expression<Func<Customer, bool>> expression)
		{
			return new Task<List<Customer>>( () => Customers.Values.AsQueryable().Where(expression).ToList());
		}

		public Task<List<Note>> GetAllNotesAsync()
		{
			return new Task<List<Note>>(() => Notes.Values.ToList());
		}

		public Task<List<Note>> GetAllNotesAsync(Expression<Func<Note, bool>> expression)
		{
			return new Task<List<Note>>(() => Notes.Values.AsQueryable().Where(expression).ToList());
		}

		public Task<List<UserAccount>> GetAllUserAccountsAsync()
		{
			return new Task<List<UserAccount>>(() => UserAccounts.Values.ToList());
		}

		public Task<List<UserAccount>> GetAllUserAccountsAsync(Expression<Func<UserAccount, bool>> expression)
		{
			return new Task<List<UserAccount>>(() => UserAccounts.Values.AsQueryable().Where(expression).ToList());
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
