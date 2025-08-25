using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Question1.Models;

namespace Question1.Controllers
{
    public class CustomerController : Controller
    {
        northwindEntities db = new northwindEntities();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomersFromGermany()
        {
            var customer1 = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customer1);
        }
        public ActionResult IdSpecificDetails()
        {
            var customer2 = db.Orders.Where(o => o.OrderID == 10248).Select(o => o.Customer).FirstOrDefault();
            return View(customer2);
        }
    }
}