using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class SoftwareController : Controller
    {
        private readonly DatabaseContext db;
        public SoftwareController(DatabaseContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Reviews()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {
            var result = db.Search(searchString);
            return Json(new { res = result });
        }
    }
}
