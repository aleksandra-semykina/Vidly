﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
	public class CustomersController : Controller
	{
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult Index()
		{
			var customers = _context.Customers.Include(x => x.MembershipType).ToList();
			return View(customers);
		}

		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(l => l.Id == id);

			if (customer == null)
			{
				return HttpNotFound();
			}

			return View(customer);
		}
	}
}