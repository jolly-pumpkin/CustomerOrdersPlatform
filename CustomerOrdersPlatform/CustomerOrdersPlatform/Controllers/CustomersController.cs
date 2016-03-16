using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerOrdersPlatform.Models;
using CustomerOrdersPlatform.Models.DAL;

namespace CustomerOrdersPlatform.Controllers
{
    public class CustomersController : Controller
    {
        public JsonResult GetCustomers()
        {
            CustomerService cs = new CustomerService(new CustomerOrdersPlatformEntities());
            var json = Json(cs.GetCustomers(), JsonRequestBehavior.AllowGet);
            return json;
        }
    }
}