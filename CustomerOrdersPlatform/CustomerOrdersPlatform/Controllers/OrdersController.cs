using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            List<Order> data = c.Orders.ToList();
            var collection = data.Select(order => new
            {
                Order_ID = order.Order_ID,
                First_Name = order.Customer.First_Name,
                Last_Name = order.Customer.Last_Name,
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

        public bool RemoveOrder(Order order)
        {
            try
            {
                CustomerOrdersPlatformEntities c = new CustomerOrdersPlatformEntities();
                c.Orders.Attach(order);
                c.Orders.Remove(order);
                c.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool CreateOrder(Order order, Order_Details orderDetails)
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