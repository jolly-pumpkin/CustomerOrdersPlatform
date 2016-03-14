using System.Linq;
using System.Web.Mvc;
using CustomerOrdersPlatform.Models.DAL;

namespace CustomerOrdersPlatform.Controllers
{
    public class ProductController : Controller
    {
        public JsonResult GetProducts()
        {
            CustomerOrdersPlatformEntities c = new CustomerOrdersPlatformEntities();
            //var result = c.Products.ToList();
            //return Json(result, JsonRequestBehavior.AllowGet);
            var data = c.Products;
            var collection = data.Select(product => new
            {
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            });
            var json = Json(collection, JsonRequestBehavior.AllowGet);
            return json;
        }
    }
}