using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.Models;
using Vidly.ViewModels;

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
            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(e => e.Id == Id);

            if (customers == null) { return HttpNotFound(); }

            return View(customers);
        }

        [Route("customers/new")]
        public ActionResult New()
        {
            ViewBag.pageTitle = "New Customer";
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerWithMembershipType
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                // Update the properties
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        [Route("customers/edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            ViewBag.pageTitle = "Edit Customer";

            var customers = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customers == null)
                return HttpNotFound();

            var viewModel = new CustomerWithMembershipType
            {
                Customer = customers,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

    }
}