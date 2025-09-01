using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Question_2.Models;

namespace Question_2.Controllers
{
    public class OrderController : ApiController
    {
        private northwindEntities db = new northwindEntities();

        [HttpGet]
        [Route("api/orders/byemployee")]
        public IHttpActionResult GetOrdersByEmployee()
        {
            var orders = db.Orders
                .Where(o => o.EmployeeID == 5)
                .Select(o => new
                {
                    o.OrderID,
                    o.OrderDate,
                    o.CustomerID,
                    o.ShipCity
                })
                .ToList();

            return Ok(orders);
        }

        [HttpGet]
        [Route("api/customers/bycountry/{country}")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var result = db.fn_CustomerWithCountryName(country).ToList();
            return Ok(result);
        }
    }
}