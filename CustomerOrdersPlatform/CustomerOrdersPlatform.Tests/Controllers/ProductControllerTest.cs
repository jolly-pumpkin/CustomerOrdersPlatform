﻿using System;

namespace CustomerOrdersPlatform.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);
            ProductService ps = new ProductService(mockContext.Object);
            {
            ps.CreateProduct(product);

        [TestMethod]
            Product product2 = new Product()
            var data = new List<Product>() { product1, product2 }.AsQueryable();
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<CustomerOrdersPlatformEntities>();
    }
}