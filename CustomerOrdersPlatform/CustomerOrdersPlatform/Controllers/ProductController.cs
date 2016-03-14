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
            var result = c.Products.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}