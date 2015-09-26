using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasonOgCRM.DomainModels;

namespace MasonOgCRM.DataAccess.EF
{
	public interface IDbContext
	{
		DbSet<Customer> Customers {get; set; }
		DbSet<Note> Notes { get; set; }
		DbSet<UserAccount> UserAccounts { get; set; }
		Task<int> SaveChangesAsync();
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
