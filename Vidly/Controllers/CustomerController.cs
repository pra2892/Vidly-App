using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("customers")]
        public ActionResult Index()
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customer);
        }

        [Route("customers/details/{Id}")]
        public ActionResult Details(int Id)
        {
            var customers = _context.Customers.SingleOrDefault(e => e.Id == Id);

            if (customers == null) { return HttpNotFound(); }

            return View(customers);
        }

        /*private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Prashant" },
                new Customer { Id = 2, Name = "Pallavi" }
            };
        }*/
    }
}