using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CustomerOrdersPlatform.Models;
using CustomerOrdersPlatform.Models.DAL;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.Extensions;

namespace CustomerOrdersPlatform.Controllers
{
    public class OrdersController : Controller
    {
        public JsonResult GetOrders()
        {
            OrderService os = new OrderService(new CustomerOrdersPlatformEntities());
            var json = Json(os.GetOrders(), JsonRequestBehavior.AllowGet);
            return json;
        }

        public JsonResult GetCustomerOrders(Customer customer)
        {
            OrderService os = new OrderService(new CustomerOrdersPlatformEntities());
            var json = Json(os.GetCustomerOrders(customer), JsonRequestBehavior.AllowGet);
            return json;
        }

        public JsonResult GetOrderDetails(Order order)
        {
            OrderService os = new OrderService(new CustomerOrdersPlatformEntities());
            var json = Json(os.GetOrderDetails(order), JsonRequestBehavior.AllowGet);
            return json;
        }

        public bool RemoveOrder(Order order)
        {
            OrderService os = new OrderService(new CustomerOrdersPlatformEntities());
            return os.RemoveOrder(order);
        }

        public bool CreateOrder(Order order)
        {
            OrderService os = new OrderService(new CustomerOrdersPlatformEntities());
            return os.CreateOrder(order);
        }
    }
}