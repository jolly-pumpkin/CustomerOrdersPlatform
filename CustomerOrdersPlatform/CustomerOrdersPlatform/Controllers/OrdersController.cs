using System.Linq;
using System.Web.Mvc;
using CustomerOrdersPlatform.Models.DAL;

namespace CustomerOrdersPlatform.Controllers
{
    public class OrdersController : Controller
    {
        public JsonResult GetOrders()
        {
            CustomerOrdersPlatformEntities c = new CustomerOrdersPlatformEntities();
            var result = c.Orders.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOrderDetails()
        {
            CustomerOrdersPlatformEntities c = new CustomerOrdersPlatformEntities();
            var result = c.Order_Details.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}