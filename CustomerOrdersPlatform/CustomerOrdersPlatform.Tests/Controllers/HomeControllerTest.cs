using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerOrdersPlatform;
using CustomerOrdersPlatform.Controllers;

namespace CustomerOrdersPlatform.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Customer()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Customers() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Orders()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Orders() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateOrder()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.CreateOrder() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
