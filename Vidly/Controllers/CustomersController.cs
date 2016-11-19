using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		//
		// GET: /Customers/
		public ActionResult Index()
		{
			var customers = GetCustomers();
			return View(customers);
		}

		public ActionResult Details(int id)
		{
			var customer = GetCustomers().SingleOrDefault(l => l.Id == id);

			if (customer == null)
			{
				return HttpNotFound();
			}

			return View(customer);
		}
		private List<Customer> GetCustomers()
		{
			var customers = new List<Customer>
			{
				new Customer { Name = "John Smith", Id = 1 },
				new Customer { Name = "Mary Williams", Id = 2 }
			};
			return customers;
		}
	}
}