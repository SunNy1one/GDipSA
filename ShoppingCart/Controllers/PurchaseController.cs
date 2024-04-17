using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using System.Diagnostics;

namespace ShoppingCart.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly DatabaseContext db;
        public PurchaseController(DatabaseContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult ViewCart(List<string> softwareIds)
        {
            Debug.WriteLine(softwareIds);
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
