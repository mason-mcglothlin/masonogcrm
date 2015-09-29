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

	/// <summary>
	/// Defines the interface that the Entity Framework DbContext will provide for the repository. Inteface used to faciliate DI.
	/// </summary>
	public interface IDbContext
	{
		DbSet<Customer> Customers {get; set; }
		DbSet<Note> Notes { get; set; }
		DbSet<UserAccount> UserAccounts { get; set; }
		Task<int> SaveChangesAsync();
		int SaveChanges();
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		void SetState(object entity, EntityState state);
    }
}
