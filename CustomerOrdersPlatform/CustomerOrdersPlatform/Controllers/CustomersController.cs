using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerOrdersPlatform.Models.DAL;

namespace CustomerOrdersPlatform.Controllers
{
    public class CustomersController : Controller
    {
        public JsonResult GetCustomers()
        {
            CustomerOrdersPlatformEntities c = new CustomerOrdersPlatformEntities();
            //List<Customer> customers = c.Customers.ToList();
            var data = c.Customers;

            var collection = data.Select(customer => new 
            {
                Customer_ID = customer.Customer_ID,
                First_Name = customer.First_Name,
                Last_Name = customer.Last_Name,
                Phone = customer.Phone,
                Address = customer.Address
            });

            var json = Json(collection, JsonRequestBehavior.AllowGet);
            return json;
        }
    }
}