using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CustomerOrdersPlatform.Models.DAL;
using Microsoft.Ajax.Utilities;

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

        public JsonResult GetCustomerOrders(Customer customer)
        {
            CustomerOrdersPlatformEntities c = new CustomerOrdersPlatformEntities();
            List<Order> data = c.Orders.ToList();
            var collection = data.Where(order => order.Customer_ID == customer.Customer_ID).Select(order => new
            {
                Order_ID = order.Order_ID,
                First_Name = order.Customer.First_Name,
                Last_Name = order.Customer.Last_Name,
                Order_Date = order.Order_Date
            });
            var json = Json(collection, JsonRequestBehavior.AllowGet);
            return json;
        }

        public JsonResult GetOrderDetails(Order order)
        {
            CustomerOrdersPlatformEntities c = new CustomerOrdersPlatformEntities();
            List<Order_Details> data = c.Order_Details.ToList();
            var collection = data.Where(detail => detail.Order_ID == order.Order_ID).Select(detail => new
            {
                Product = new Product()
                {
                 SKU   = detail.Product.SKU,
                 Name  = detail.Product.Name,
                 Description = detail.Product.Description,
                 Price = detail.Product.Price
                }
            });
            var json = Json(collection, JsonRequestBehavior.AllowGet);
            return json;
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