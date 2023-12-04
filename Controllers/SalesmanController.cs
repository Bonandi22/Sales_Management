using Microsoft.AspNetCore.Mvc;

namespace Sales_Management.Controllers
{
    public class SalesmanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
