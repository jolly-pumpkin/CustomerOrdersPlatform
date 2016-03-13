using System.Linq;
using System.Web.Mvc;
using CustomerOrdersPlatform.Persistence.Orders;
using CustomerOrdersPlatform.Persistence.OrderDetails;

namespace CustomerOrdersPlatform.Controllers
{
    public class OrdersController : Controller
    {
        public JsonResult GetOrders()
        {
            CustomerOrdersEntitiesOrders coe = new CustomerOrdersEntitiesOrders();
            var result = coe.Orders.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOrderDetails()
        {
            CustomerOrdersEntitiesOrderDetails coe = new CustomerOrdersEntitiesOrderDetails();
            var result = coe.Order_Details.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}