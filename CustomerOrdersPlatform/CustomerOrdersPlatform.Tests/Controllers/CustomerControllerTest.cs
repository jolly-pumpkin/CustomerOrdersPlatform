using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using CustomerOrdersPlatform.Models;
using CustomerOrdersPlatform.Models.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CustomerOrdersPlatform.Tests.Controllers
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void CreateCustomer()
        {
            var mockSet = new Mock<DbSet<Customer>>();
            var mockContext = new Mock<CustomerOrdersPlatformEntities>();

            mockContext.Setup(m => m.Customers).Returns(mockSet.Object);

            CustomerService cs = new CustomerService(mockContext.Object);
            Customer customer = new Customer()
            {
                Customer_ID = 1,
                First_Name = "First",
                Last_Name = "Last",
                Address = "123 road",
                Phone = "123-345-1234"
            };
            cs.CreateCustomer(customer);
            mockSet.Verify(m => m.Add(It.IsAny<Customer>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetCustomers()
        {
            Customer customer1 = new Customer()
            {
                Customer_ID = 1,
                First_Name = "John",
                Last_Name = "Doe",
                Address = "123 road",
                Phone = "123-345-1234"
            };
            Customer customer2 = new Customer()
            {
                Customer_ID = 2,
                First_Name = "Jane",
                Last_Name = "Doe",
                Address = "123 court",
                Phone = "342-345-5232"
            };
            var data = new List<Customer>() {customer1, customer2}.AsQueryable();
            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(data.Provider);            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(data.Expression);            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(data.ElementType);            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
            var mockContext = new Mock<CustomerOrdersPlatformEntities>();
            mockContext.Setup(c => c.Customers).Returns(mockSet.Object);
            CustomerService cs = new CustomerService(mockContext.Object);
            var customers = cs.GetCustomers();
            Assert.AreEqual(2, customers.Count);
        }
    }
}
