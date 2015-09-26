using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasonOgCRM.DataAccess.EF;
using MasonOgCRM.DomainModels;
using Moq;
using NUnit.Framework;

namespace DataAccess.EF.Tests
{
	public class EntityFrameworkRepositoryTestsAsync
	{
		Mock<IDbContext> dbContext;
		Mock<DbSet<Customer>> mockSet;
		Customer mason;

		[TestFixtureSetUp]
		public void SetupDbContext()
		{
			dbContext = new Mock<IDbContext>();

			mason = new Customer { Id = 2, FirstName = "Mason", LastName = "McGlothlin", Address = "1 Washington Way", CompanyName = "Acme Inc", EmailAddress = "mason@compuserve.com", PhoneNumber = "555-555-5555" };

			var sampleCustomerData = new List<Customer>
			{
				new Customer { Id = 1, FirstName = "Road", LastName = "Runner", Address = "2 Test Ave", CompanyName = "Stuff Inc", EmailAddress = "road@aol.com", PhoneNumber = "817-555-5555" },
				mason,
				new Customer { Id = 3, FirstName = "Bobby", LastName = "Tables", Address = "XKCD Street", CompanyName = "Funny Stuff LLC", EmailAddress = "randall@xkcd.net", PhoneNumber = "214-555-5555" },
			}.AsQueryable();

			mockSet = new Mock<DbSet<Customer>>();
			mockSet.As<IDbAsyncEnumerable<Customer>>()
				.Setup(m => m.GetAsyncEnumerator())
				.Returns(new TestDbAsyncEnumerator<Customer>(sampleCustomerData.GetEnumerator()));

			mockSet.As<IQueryable<Customer>>()
				.Setup(m => m.Provider)
				.Returns(new TestDbAsyncQueryProvider<Customer>(sampleCustomerData.Provider));

			mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(sampleCustomerData.Expression);
			mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(sampleCustomerData.ElementType);
			mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(sampleCustomerData.GetEnumerator());

			dbContext.Setup(c => c.Customers).Returns(mockSet.Object);

			mockSet.Setup(c => c.Add(It.IsAny<Customer>())).Returns(new Customer()).Verifiable();
			
			dbContext.Setup(c => c.SaveChangesAsync()).Verifiable();
		}

		[Test]
		public async Task FindCustomerByIdAsync()
		{
			//Arrange
			var repository = new EntityFrameworkRepository(dbContext.Object);

			//Act
			var customer = await repository.FindCustomerByIdAsync(mason.Id);

			//Assert
			Assert.IsNotNull(customer);
			Assert.AreEqual(mason.Id, customer.Id);
			Assert.AreEqual(mason.FirstName, customer.FirstName);
			Assert.AreEqual(mason.LastName, customer.LastName);
			Assert.AreEqual(mason.Address, customer.Address);
			Assert.AreEqual(mason.CompanyName, customer.CompanyName);
			Assert.AreEqual(mason.EmailAddress, customer.EmailAddress);
			Assert.AreEqual(mason.PhoneNumber, customer.PhoneNumber);
		}

		[Test]
		public async Task AddCustomerAsync()
		{
			//Arrange
			var repository = new EntityFrameworkRepository(dbContext.Object);
			var customer = new Customer() { FirstName = "Larry", LastName = "Hughes" };

			//Act
			await repository.AddCustomerAsync(customer);

			//Assert
			dbContext.Verify(c => c.Customers.Add(It.IsAny<Customer>()));
			dbContext.Verify(c => c.SaveChangesAsync());
        }
	}
}
