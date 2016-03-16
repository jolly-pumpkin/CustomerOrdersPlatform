using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CustomerOrdersPlatform.Models;
using CustomerOrdersPlatform.Models.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CustomerOrdersPlatform.Tests.Controllers
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void CreateOrder()
        {
            var mockSet = new Mock<DbSet<Order>>();
            var mockContext = new Mock<CustomerOrdersPlatformEntities>();

            mockContext.Setup(m => m.Orders).Returns(mockSet.Object);
            
            Order_Details details = new Order_Details()
            {
                Detail_ID = 1,
                Order_ID = 1,
                Product_SKU = "abc-1234"
            };
            Order order = new Order()
            {
                Order_ID = 1,
                Order_Date = System.DateTime.Now
            };
            order.Order_Details.Add(details);

            OrderService os = new OrderService(mockContext.Object);
            os.CreateOrder(order);
            mockSet.Verify(m => m.Add(It.IsAny<Order>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetOrders()
        {
            Order order1 = new Order()
            {
                Order_ID = 1,
                Order_Date = System.DateTime.Now
            };
            Customer c1 = new Customer()
            {
                First_Name = "John",
                Last_Name = "Doe"
            };
            order1.Customer = c1;

            Order order2 = new Order()
            {
                Order_ID = 2,
                Order_Date = System.DateTime.Now
            };
            Customer c2 = new Customer()
            {
                First_Name = "Jane",
                Last_Name = "Doe"
            };
            order2.Customer = c2;

            var data = new List<Order>() {order1, order2}.AsQueryable();
            var mockSet = new Mock<DbSet<Order>>();
            mockSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<CustomerOrdersPlatformEntities>();
            mockContext.Setup(c => c.Orders).Returns(mockSet.Object);
            OrderService os = new OrderService(mockContext.Object);
            var orders = os.GetOrders();
            Assert.AreEqual(2, orders.Count);
        }

        [TestMethod]
        public void RemoveOrder()
        {
            Order order1 = new Order()
            {
                Order_ID = 1,
                Order_Date = System.DateTime.Now
            };
            Customer c1 = new Customer()
            {
                First_Name = "John",
                Last_Name = "Doe"
            };
            order1.Customer = c1;

            Order order2 = new Order()
            {
                Order_ID = 2,
                Order_Date = System.DateTime.Now
            };
            Customer c2 = new Customer()
            {
                First_Name = "Jane",
                Last_Name = "Doe"
            };
            order2.Customer = c2;

            var data = new List<Order>() { order1, order2 }.AsQueryable();
            var mockSet = new Mock<DbSet<Order>>();
            mockSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<CustomerOrdersPlatformEntities>();
            mockContext.Setup(c => c.Orders).Returns(mockSet.Object);
            OrderService os = new OrderService(mockContext.Object);
            var result = os.RemoveOrder(order1);
            mockSet.Verify(m => m.Remove(It.IsAny<Order>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetOrderDetails()
        {
            Order_Details details1 = new Order_Details()
            {
                Detail_ID = 1,
                Order_ID = 1,
            };
            Product product1 = new Product()
            {
                SKU = "asd-123",
                Name = "widget",
                Description = "fake awesome",
                Price = 9.99m
            };
            details1.Product = product1;
            Order_Details details2 = new Order_Details()
            {
                Detail_ID = 2,
                Order_ID = 1,
            };
            Product product2 = new Product()
            {
                SKU = "dfa-132",
                Name = "table",
                Description = "round wood table",
                Price = 199.50m
            };
            details2.Product = product2;
            Order order1 = new Order()
            {
                Order_ID = 1,
                Order_Date = System.DateTime.Now
            };
            order1.Order_Details.Add(details1);

            var data = new List<Order_Details>() { details1, details2 }.AsQueryable();
            var mockSet = new Mock<DbSet<Order_Details>>();
            mockSet.As<IQueryable<Order_Details>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Order_Details>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Order_Details>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Order_Details>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<CustomerOrdersPlatformEntities>();
            mockContext.Setup(c => c.Order_Details).Returns(mockSet.Object);

            OrderService os = new OrderService(mockContext.Object);
            var ordersDetails = os.GetOrderDetails(order1);
            Assert.AreEqual(2, ordersDetails.Count);
        }

        [TestMethod]
        public void GetCustomerOrders()
        {

            Order order1 = new Order()
            {
                Order_ID = 1,
                Customer_ID = 1,
                Order_Date = System.DateTime.Now
            };
            Customer c1 = new Customer()
            {
                Customer_ID = 1,
                First_Name = "John",
                Last_Name = "Doe"
            };
            order1.Customer = c1;

            Order order2 = new Order()
            {
                Order_ID = 2,
                Customer_ID = 2,
                Order_Date = System.DateTime.Now
            };
            Customer c2 = new Customer()
            {
                Customer_ID = 2,
                First_Name = "Jane",
                Last_Name = "Doe"
            };
            order2.Customer = c2;

            var data = new List<Order>() { order1, order2 }.AsQueryable();
            var mockSet = new Mock<DbSet<Order>>();
            mockSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<CustomerOrdersPlatformEntities>();
            mockContext.Setup(c => c.Orders).Returns(mockSet.Object);
            OrderService os = new OrderService(mockContext.Object);
            var orders = os.GetCustomerOrders(c1);
            Assert.AreEqual(1, orders.Count);
        }
    }
}
