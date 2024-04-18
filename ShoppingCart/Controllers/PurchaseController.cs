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


        [HttpPost]
        public IActionResult ViewCart(List<string> softwaresToBuy)
        {
            Debug.WriteLine(softwaresToBuy);
            return Json(new {
                softwares = softwaresToBuy
            });
        }

        public IActionResult PastPurchase()
        {
            ISession session = HttpContext.Session;
            string? username = session.GetString("username");
            if(username != null)
            {
                var purchases = db.GetPastPurchase(username);
                return View(purchases);
            }
            return View();
        }
    }
}
