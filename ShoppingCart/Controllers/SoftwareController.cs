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
            ViewData["userId"] = user.userId;
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
            return View("Index");
        }

        [HttpPost]
        public IActionResult AddToCart(int softwareId)
        {
            int cartCount = GetCartCount();
            cartCount++;
            HttpContext.Session.SetInt32("CartCount", cartCount);
            return RedirectToAction("ViewCart", "Purchase");
        }

        private int GetCartCount()
        {
            return HttpContext.Session.GetInt32("CartCount") ?? 0;
        }
    }
}
