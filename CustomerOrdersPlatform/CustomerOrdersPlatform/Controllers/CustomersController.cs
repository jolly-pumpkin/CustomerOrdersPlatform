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
            var result = c.Customers.ToList();
            var json = Json(result, JsonRequestBehavior.AllowGet);
            return json;
        }
    }
}