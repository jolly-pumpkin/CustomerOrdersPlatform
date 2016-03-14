using System;
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
            //var result = c.Orders.ToList();
            //return Json(result, JsonRequestBehavior.AllowGet);

            var data = c.Orders;
            var collection = data.Select(order => new
            {
                Order_ID = order.Order_ID,
                Customer_ID = order.Customer_ID,
                Order_Date = order.Order_Date
            });
            var json = Json(collection, JsonRequestBehavior.AllowGet);
            return json;
        }

        public JsonResult GetOrderDetails()
        {
            CustomerOrdersPlatformEntities c = new CustomerOrdersPlatformEntities();
            var result = c.Order_Details.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public bool CreateOrder(Order order)
        {
            try
            {
                CustomerOrdersPlatformEntities c = new CustomerOrdersPlatformEntities();
                c.Orders.Add(order);
                c.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}