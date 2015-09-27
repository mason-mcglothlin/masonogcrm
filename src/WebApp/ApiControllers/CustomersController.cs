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

		public IEnumerable<Customer> Get()
		{
			return Repository.GetAllCustomers();
		}

		public Customer Get(int id)
		{
			return Repository.FindCustomerById(id);
		}

		public void Post([FromBody]Customer customer)
		{
			Repository.AddCustomer(customer);
		}

		public void Put([FromBody]Customer customer)
		{
			Repository.UpdateCustomer(customer);
		}

		public void Delete(int id)
		{
			Repository.DeleteCustomer(id);
		}
	}
}