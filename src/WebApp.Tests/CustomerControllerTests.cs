using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MasonOgCRM.DataAccess.Common;
using MasonOgCRM.DomainModels;
using MasonOgCRM.WebApp.Controllers;
using Moq;
using NUnit.Framework;

namespace WebApp.Tests
{
	[TestFixture]
	public class CustomerControllerTests
	{

		List<Customer> sampleCustomerData = new List<Customer>
			{
				new Customer { Id = 1, FirstName = "Road", LastName = "Runner", Address = "2 Test Ave", CompanyName = "Stuff Inc", EmailAddress = "road@aol.com", PhoneNumber = "817-555-5555" },
				new Customer { Id = 3, FirstName = "Bobby", LastName = "Tables", Address = "XKCD Street", CompanyName = "Funny Stuff LLC", EmailAddress = "randall@xkcd.net", PhoneNumber = "214-555-5555" },
			}.ToList();

		[Test]
		public async Task Index()
		{
			//Arrange
			var repository = new Mock<IOgCRMRepository>();
			repository.Setup(r => r.GetAllCustomersAsync()).ReturnsAsync(sampleCustomerData);
			var customerController = new CustomersController(repository.Object);

			//Act
			var result = await customerController.Index();

			//Assert
			Assert.IsInstanceOf<ViewResult>(result);
			var viewResult = result as ViewResult;
			Assert.IsInstanceOf<IEnumerable<Customer>>(viewResult.Model);
			Assert.AreEqual(sampleCustomerData.Count, (viewResult.Model as IEnumerable<Customer>).Count());
		}
	}
}
