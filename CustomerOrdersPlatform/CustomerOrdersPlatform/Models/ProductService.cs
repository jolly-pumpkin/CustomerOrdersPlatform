using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerOrdersPlatform.Models.DAL;

namespace CustomerOrdersPlatform.Models
{
    public class ProductService
    {
        private CustomerOrdersPlatformEntities _context;

        public ProductService(CustomerOrdersPlatformEntities context)
        {
            _context = context;
        }

        public object GetProducts()
        {
            var data = _context.Products;
            var collection = data.Select(product => new
            {
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            });
            return collection;
        }
    }
}