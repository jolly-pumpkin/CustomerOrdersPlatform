using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerOrdersPlatform.Persistence.Customer;

namespace CustomerOrdersPlatform.Controllers
{
    public class CustomersController : Controller
    {
        public JsonResult GetLastCustomer()
        {
            CustomerOrdersEntities coe = new CustomerOrdersEntities();
            var result = coe.Customers.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}