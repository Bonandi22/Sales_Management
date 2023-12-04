using Microsoft.AspNetCore.Mvc;

namespace Sales_Management.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
