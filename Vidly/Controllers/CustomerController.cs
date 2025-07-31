using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        [Route("customers")]
        public ActionResult Index()
        {
            List<Customer> customer = new List<Customer>()
            {
                new Customer() { Id = 1, Name = "Prashant"},
                new Customer() { Id = 2, Name = "Pallavi"}
            };

            return View(customer);
        }

        [Route("customers/details/{Id}")]
        public ActionResult Details(int Id)
        {
            List<Customer> customer = new List<Customer>()
            {
                new Customer() { Id = 1, Name = "Prashant"},
                new Customer() { Id = 2, Name = "Pallavi"}
            };

            List<Customer> searchCustomer = customer.Where(item => item.Id == Id).ToList();

            return View(searchCustomer);
        }
    }
}