using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class SoftwareController : Controller
    {
        private readonly DbContext db;
        public SoftwareController(DbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            Data data = new Data();
            return View(data.softwares);
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
