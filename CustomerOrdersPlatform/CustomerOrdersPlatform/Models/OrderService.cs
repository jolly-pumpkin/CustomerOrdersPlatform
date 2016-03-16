using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerOrdersPlatform.Models.DAL;

namespace CustomerOrdersPlatform.Models
{
    public class OrderService
    {
        private CustomerOrdersPlatformEntities _context;

        public OrderService(CustomerOrdersPlatformEntities context)
        {
            _context = context;
        }

        public List<object> GetOrders()
        {
            List<Order> data = _context.Orders.ToList();
            var collection = data.Select(order => new
            {
                Order_ID = order.Order_ID,
                First_Name = order.Customer.First_Name,
                Last_Name = order.Customer.Last_Name,
                Order_Date = order.Order_Date.ToString().Split(' ')[0],
                Total = order.Order_Details.Select(detail => detail.Product.Price).ToArray().Sum(x => Convert.ToDecimal(x))
            }).ToList<object>();
            return collection;
        }

        public List<object> GetCustomerOrders(Customer customer)
        {
            List<Order> data = _context.Orders.ToList();
            var collection = data.Where(order => order.Customer_ID == customer.Customer_ID).Select(order => new
            {
                Order_ID = order.Order_ID,
                First_Name = order.Customer.First_Name,
                Last_Name = order.Customer.Last_Name,
                Order_Date = order.Order_Date.ToString().Split(' ')[0],
                Total = order.Order_Details.Select(detail => detail.Product.Price).ToArray().Sum(x => Convert.ToDecimal(x))
            }).ToList<object>();
            return collection;
        }

        public List<object> GetOrderDetails(Order order)
        {
            var data = _context.Order_Details;
            var collection = data.Where(detail => detail.Order_ID == order.Order_ID).Select(detail => new
            {
                Product = new Product()
                {
                    SKU = detail.Product.SKU,
                    Name = detail.Product.Name,
                    Description = detail.Product.Description,
                    Price = detail.Product.Price
                }
            }).ToList<object>();
            return collection;
        }

        public bool RemoveOrder(Order order)
        {
            try
            {
                _context.Orders.Attach(order);
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool CreateOrder(Order order)
        {
            try
            {
                order.Order_Date = System.DateTime.Now;
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}