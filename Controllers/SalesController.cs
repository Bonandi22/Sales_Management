using Microsoft.AspNetCore.Mvc;

namespace Sales_Management.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
