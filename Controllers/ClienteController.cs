using Microsoft.AspNetCore.Mvc;

namespace Sales_Management.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
