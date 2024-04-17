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
        public IActionResult Index(User user)
        {
            ViewData["username"] = user.username;
            return View(db.GetAllSoftware());
        }

        public IActionResult Reviews()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {
            var result = db.Search(searchString);
            ViewData["search-result"] = result;
            return View("Index", result);
        }

        List<string> softwareInCart = new List<string>();

        [HttpPost]
        public IActionResult AddToCart(string softwareId)
        {
            softwareInCart.Add(softwareId.ToString());
            int cartCount = GetCartCount();
            cartCount++;
            HttpContext.Session.SetInt32("CartCount", softwareInCart.Count);
            return View("Index", db.GetAllSoftware());
        }

        private int GetCartCount()
        {
            return HttpContext.Session.GetInt32("CartCount") ?? 0;
        }
    }
}
