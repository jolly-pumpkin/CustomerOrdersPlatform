using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerOrdersPlatform.Models.DAL;

namespace CustomerOrdersPlatform.Models
{
    public class CustomerService
    {
        private CustomerOrdersPlatformEntities _context;

        public CustomerService(CustomerOrdersPlatformEntities context)
        {
            _context = context;
        }

        public object GetCustomers()
        {
            var data = _context.Customers;
            var collection = data.Select(customer => new
            {
                Customer_ID = customer.Customer_ID,
                First_Name = customer.First_Name,
                Last_Name = customer.Last_Name,
                Phone = customer.Phone,
                Address = customer.Address
            });
            return collection;
        }

    }
}