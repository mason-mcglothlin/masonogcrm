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
	class EFDBContext : DbContext
	{
		/// <summary>
		/// Constructor for creating a new EFDBContext with the specified connection string.
		/// </summary>
		/// <param name="connectionString">Entity Framework connection string to use for accessing the database.</param>
		public EFDBContext(string connectionString): base(connectionString) { }

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
	}
}
