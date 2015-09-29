using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MasonOgCRM.DataAccess.Common;
using MasonOgCRM.DomainModels;

namespace MasonOgCRM.WebApp.ApiControllers
{
	/// <summary>
	/// Provides a REST-based API for outside programs to interact with the customers.
	/// </summary>
	public class CustomersController : ApiController
	{
		private readonly IOgCRMRepository Repository;

		/// <summary>
		/// Create an instance of the Customers ApiController.
		/// </summary>
		/// <param name="repository">A repository to provide CRUD of entities.</param>
		public CustomersController(IOgCRMRepository repository)
		{
			Repository = repository;
		}

		/// <summary>
		/// Get all customers in the repository.
		/// </summary>
		/// <returns>A collection of all customers in the repository.</returns>
		public IEnumerable<Customer> Get()
		{
			return Repository.GetAllCustomers();
		}

		/// <summary>
		/// Get a specific customer by Id from the repository.
		/// </summary>
		/// <param name="id">The Id of the customer to retrieve.</param>
		/// <returns>The customer represented by Id.</returns>
		public Customer Get(int id)
		{
			return Repository.FindCustomerById(id);
		}

		/// <summary>
		/// Adds a new customer to the repository.
		/// </summary>
		/// <param name="customer">New customer to add to the repository.</param>
		public void Post([FromBody]Customer customer)
		{
			Repository.AddCustomer(customer);
		}

		/// <summary>
		/// Update a customer that exists in the repository.
		/// </summary>
		/// <param name="customer">A customer object representing the changes to be made. The Id must match the customer to be updated.</param>
		public void Put([FromBody]Customer customer)
		{
			Repository.UpdateCustomer(customer);
		}

		/// <summary>
		/// Removes a customer from the repository.
		/// </summary>
		/// <param name="id"></param>
		public void Delete(int id)
		{
			Repository.DeleteCustomer(id);
		}
	}
}