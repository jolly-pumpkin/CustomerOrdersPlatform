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

        public List<object> GetProducts()
        {
            var data = _context.Products;
            var collection = data.Select(product => new
            {
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            }).ToList<object>();
            return collection;
        }

        public bool CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
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