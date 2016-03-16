using System.Linq;
using System.Web.Mvc;
using CustomerOrdersPlatform.Models;
using CustomerOrdersPlatform.Models.DAL;

namespace CustomerOrdersPlatform.Controllers
{
    public class ProductController : Controller
    {
        public JsonResult GetProducts()
        {
            ProductService ps = new ProductService(new CustomerOrdersPlatformEntities());
            var json = Json(ps.GetProducts(), JsonRequestBehavior.AllowGet);
            return json;
        }
    }
}