using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class SoftwareController : Controller
    {
        public IActionResult Index()
        {
            Data data = new Data();
            return View(data.softwares);
        }

        public IActionResult Reviews()
        {
            return View();
        }

        public IActionResult Search(string searchString)
        {
            return View();
        }
    }
}
