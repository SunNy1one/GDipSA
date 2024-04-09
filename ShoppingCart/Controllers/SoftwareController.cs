using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers
{
    public class SoftwareController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reviews()
        {
            return View();
        }
    }
}
