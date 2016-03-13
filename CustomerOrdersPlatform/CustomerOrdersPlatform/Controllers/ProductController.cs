using System.Linq;
using System.Web.Mvc;
using CustomerOrdersPlatform.Persistence.Product;

namespace CustomerOrdersPlatform.Controllers
{
    public class ProductController : Controller
    {
        public JsonResult GetProducts()
        {
            CustomerOrdersEntityProducts coe = new CustomerOrdersEntityProducts();
            var result = coe.Products.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}