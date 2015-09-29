using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MasonOgCRM.DataAccess.EF;
using Moq;
using MasonOgCRM.DomainModels;
using System.Data.Entity;
using MasonOgCRM.DataAccess.Common;

namespace DataAccess.EF.Tests
{
	[TestFixture]
	public class EntityFrameworkRepositoryTests
	{
		Mock<IDbContext> dbContext;
		Mock<DbSet<Customer>> mockCustomerSet;
		Customer mason;

		private EntityFrameworkRepository CreateRepository()
		{
			Mock<IPasswordHasher> hasher = new Mock<IPasswordHasher>();
			return new EntityFrameworkRepository(dbContext.Object, hasher.Object);
		}

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

			mockCustomerSet = new Mock<DbSet<Customer>>();
			mockCustomerSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(sampleCustomerData.Provider);
			mockCustomerSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(sampleCustomerData.Expression);
			mockCustomerSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(sampleCustomerData.ElementType);
			mockCustomerSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(sampleCustomerData.GetEnumerator());
			mockCustomerSet.Setup(c => c.Add(It.IsAny<Customer>())).Returns(new Customer()).Verifiable();
			dbContext.Setup(c => c.Customers).Returns(mockCustomerSet.Object);
			dbContext.Setup(c => c.SaveChanges()).Verifiable();
		}

		[Test]
		public void FindCustomerById()
		{
			//Arrange
			var repository = CreateRepository();

			//Act
			var customer = repository.FindCustomerById(mason.Id);

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
		public void AddCustomer()
		{
			//Arrange
			var repository = CreateRepository();
			var customer = new Customer() { FirstName = "Larry", LastName = "Hughes" };

			//Act
			repository.AddCustomer(customer);

			//Assert
			mockCustomerSet.Verify(c => c.Add(It.IsAny<Customer>()));
			dbContext.Verify(c => c.SaveChanges());
		}

		[Test]
		public void GetCustomerTotalCount()
		{
			//Arrange
			var expectedCount = mockCustomerSet.Object.Count();
			var repository = CreateRepository();

			//Act
			var actualCount = repository.GetCustomerTotalCount();

			//Assert
			Assert.AreEqual(expectedCount, actualCount);
		}

		[Test]
		public void DeleteCustomer()
		{
			//Arrange
			var repository = CreateRepository();

			//Act
			repository.DeleteCustomer(mason.Id);

			//Assert
			dbContext.Verify(c => c.SetState(mason, EntityState.Deleted));
			dbContext.Verify(c => c.SaveChanges());
		}

		[Test]
		public void GetAllCustomers()
		{
			//Arrange
			var repository = CreateRepository();

			//Act
			var customers = repository.GetAllCustomers();

			//Assert
			Assert.IsNotNull(customers);
			Assert.AreEqual(mockCustomerSet.Object.Count(), customers.Count);
		}

		[Test]
		public void GetAllCustomersByExpression()
		{
			//Arrange
			var repository = CreateRepository();

			//Act
			var customers = repository.GetAllCustomers(c => c.CompanyName.Contains("Inc"));

			//Assert
			Assert.IsNotNull(customers);
			Assert.AreEqual(2, customers.Count);
		}

		[Test]
		public void GetAllCustomerIds()
		{
			//Arrange
			var expectedIds = mockCustomerSet.Object.Select(c => c.Id).ToList();
			var expectedIdCount = expectedIds.Count();
			var repository = CreateRepository();

			//Act
			var actualIds = repository.GetAllCustomerIds();

			//Assert
			Assert.AreEqual(expectedIdCount, expectedIdCount);
			foreach (var expectedId in expectedIds)
			{
				Assert.Contains(expectedId, actualIds);
			}
		}
	}
}
