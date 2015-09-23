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
	public class EntityFrameworkRepository : IOgCRMRepository
	{
		public Task AddCustomer(Customer customer)
		{
			throw new NotImplementedException();
		}

		public Task AddNote(Note userAccount)
		{
			throw new NotImplementedException();
		}

		public Task AddUserAccount(UserAccount userAccount)
		{
			throw new NotImplementedException();
		}

		public Task DeleteCustomer(int id)
		{
			throw new NotImplementedException();
		}

		public Task DeleteNote(int id)
		{
			throw new NotImplementedException();
		}

		public Task DeleteUserAccount(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Customer> FindCustomerByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Note> FindNoteByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<UserAccount> FindUserAccountByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Customer>> GetAllCustomers(Expression<Func<bool>> expression)
		{
			throw new NotImplementedException();
		}

		public Task<List<Customer>> GetAllCustomersAsync()
		{
			throw new NotImplementedException();
		}

		public Task<List<Note>> GetAllNotes(Expression<Func<bool>> expression)
		{
			throw new NotImplementedException();
		}

		public Task<List<Note>> GetAllNotesAsync()
		{
			throw new NotImplementedException();
		}

		public Task<List<UserAccount>> GetAllUserAccounts(Expression<Func<bool>> expression)
		{
			throw new NotImplementedException();
		}

		public Task<List<UserAccount>> GetAllUserAccountsAsync()
		{
			throw new NotImplementedException();
		}

		public Task UpdateCustomer(Customer customer)
		{
			throw new NotImplementedException();
		}

		public Task UpdateNote(Note userAccount)
		{
			throw new NotImplementedException();
		}

		public Task UpdateUserAccount(UserAccount userAccount)
		{
			throw new NotImplementedException();
		}
	}
}
