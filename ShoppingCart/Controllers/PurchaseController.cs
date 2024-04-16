using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly DbContext db;
        public PurchaseController(DbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCart() 
        {
            return View();
        }

        public IActionResult ViewCart()
        {
            return View();
        }

        public IActionResult PastPurchase()
        {
            ISession session = HttpContext.Session;
            string? userId = session.GetString("userId");
            if(userId != null)
            {
                var purchases = db.GetPastPurchase(userId);
                return View(purchases);
            }
            return View();
        }
    }
}
