using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasonOgCRM.DomainModels;

namespace MasonOgCRM.DataAccess.EF
{
	/// <summary>
	/// Entity framework DbContext for accessing the database.
	/// </summary>
	public class EFDBContext : DbContext, IDbContext
	{
		/// <summary>
		/// Empty constructor for testing. Do not use.
		/// </summary>
		public EFDBContext()
		{

		}

		/// <summary>
		/// Constructor for creating a new EFDBContext with the specified connection string.
		/// </summary>
		/// <param name="connectionString">Entity Framework connection string to use for accessing the database.
		/// Can be a connection string name or full connection string.</param>
		public EFDBContext(string connectionString) : base(connectionString) { }


		/// <summary>
		/// Configure EF model primary and foreign keys by overriding DbContext.OnModelCreating
		/// </summary>
		/// <remarks>
		/// Since the entities are in an entirely separate class library that does not reference EF, this method uses the EF Fluent API to configure the relationships between entities.
		/// </remarks>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>().HasKey(customer => customer.Id);
			modelBuilder.Entity<Note>().HasKey(note => note.Id);
			modelBuilder.Entity<UserAccount>().HasKey(userAccount => userAccount.Id);
		}

		/// <summary>
		/// Object to call methods against for interacting with Customer objects in the database.
		/// </summary>
		public DbSet<Customer> Customers { get; set; }

		/// <summary>
		/// Object to call methods against for interacting with Note objects in the database.
		/// </summary>
		public DbSet<Note> Notes { get; set; }

		/// <summary>
		/// Object to call methods against for interacting with UserAccount objects in the database.
		/// </summary>
		public DbSet<UserAccount> UserAccounts { get; set; }

		public void SetState(object entity, EntityState state)
		{
			Entry(entity).State = state;
		}
	}
}
