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
	public class CustomersController : ApiController
	{
		private readonly IOgCRMRepository Repository;

		public CustomersController(IOgCRMRepository repository)
		{
			Repository = repository;
		}

		// GET api/<controller>
		public async Task<IEnumerable<Customer>> Get()
		{
			return await Repository.GetAllCustomersAsync();
		}

		// GET api/<controller>/5
		public async Task<Customer> Get(int id)
		{
			return await Repository.FindCustomerByIdAsync(id);
		}

		// POST api/<controller>
		public async Task Post([FromBody]Customer customer)
		{
			await Repository.AddCustomerAsync(customer);
		}

		// PUT api/<controller>
		public async Task Put([FromBody]Customer customer)
		{
			await Repository.UpdateCustomerAsync(customer);
		}

		// DELETE api/<controller>/5
		public async Task Delete(int id)
		{
			await Repository.DeleteCustomerAsync(id);
		}
	}
}