using System;using System.Collections.Generic;using System.Data.Entity;using System.Linq;using System.Text;using System.Threading.Tasks;using CustomerOrdersPlatform.Models;using CustomerOrdersPlatform.Models.DAL;using Microsoft.VisualStudio.TestTools.UnitTesting;using Moq;using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerOrdersPlatform.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]        public void CreateProduct()        {            var mockSet = new Mock<DbSet<Product>>();            var mockContext = new Mock<CustomerOrdersPlatformEntities>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);
            ProductService ps = new ProductService(mockContext.Object);            Product product = new Product()
            {                SKU = "asd-123",                Name = "widget",                Description = "fake awesome",                Price = 9.99m            };
            ps.CreateProduct(product);            mockSet.Verify(m => m.Add(It.IsAny<Product>()), Times.Once);            mockContext.Verify(m => m.SaveChanges(), Times.Once);        }

        [TestMethod]        public void GetProducts()        {            Product product1 = new Product()            {                SKU = "asd-123",                Name = "widget",                Description = "fake awesome",                Price = 9.99m            };
            Product product2 = new Product()            {                SKU = "dfa-132",                Name = "table",                Description = "round wood table",                Price = 199.50m            };
            var data = new List<Product>() { product1, product2 }.AsQueryable();            var mockSet = new Mock<DbSet<Product>>();            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<CustomerOrdersPlatformEntities>();            mockContext.Setup(c => c.Products).Returns(mockSet.Object);            ProductService ps = new ProductService(mockContext.Object);            var products = ps.GetProducts();            Assert.AreEqual(2, products.Count);        }
    }
}
