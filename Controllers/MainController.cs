using Microsoft.AspNetCore.Mvc;

namespace Sales_Management.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Main()
        {
            return View();
        }
    }
}
