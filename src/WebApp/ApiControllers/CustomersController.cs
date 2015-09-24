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

		public async Task<IEnumerable<Customer>> Get()
		{
			return await Repository.GetAllCustomersAsync();
		}

		public async Task<Customer> Get(int id)
		{
			return await Repository.FindCustomerByIdAsync(id);
		}

		public async Task Post([FromBody]Customer customer)
		{
			await Repository.AddCustomerAsync(customer);
		}

		public async Task Put([FromBody]Customer customer)
		{
			await Repository.UpdateCustomerAsync(customer);
		}

		public async Task Delete(int id)
		{
			await Repository.DeleteCustomerAsync(id);
		}
	}
}