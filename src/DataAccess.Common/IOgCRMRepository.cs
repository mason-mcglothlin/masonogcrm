using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MasonOgCRM.DomainModels;

namespace MasonOgCRM.DataAccess.Common
{
	public interface IOgCRMRepository
	{
		Task<Customer> FindCustomerByIdAsync(int id);
		Task<List<Customer>> GetAllCustomersAsync();
		Task<List<Customer>> GetAllCustomers(Expression<Func<bool>> expression);
		Task DeleteCustomer(int id);
		Task UpdateCustomer(Customer customer);
		Task AddCustomer(Customer customer);

		Task<UserAccount> FindUserAccountByIdAsync(int id);
		Task<List<UserAccount>> GetAllUserAccountsAsync();
		Task<List<UserAccount>> GetAllUserAccounts(Expression<Func<bool>> expression);
		Task DeleteUserAccount(int id);
		Task UpdateUserAccount(UserAccount userAccount);
		Task AddUserAccount(UserAccount userAccount);

		Task<Note> FindNoteByIdAsync(int id);
		Task<List<Note>> GetAllNotesAsync();
		Task<List<Note>> GetAllNotes(Expression<Func<bool>> expression);
		Task DeleteNote(int id);
		Task UpdateNote(Note userAccount);
		Task AddNote(Note userAccount);
	}
}
