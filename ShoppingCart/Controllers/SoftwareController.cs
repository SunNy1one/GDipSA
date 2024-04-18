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

        public IActionResult ViewCart_2()
        {
            return View(new List<ShoppingcartModel>() { new ShoppingcartModel("1", (decimal)1.0, (decimal)1.0, (decimal)1.0, "/images/numerics.jpg", "item") });
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

        [HttpGet]
        public IActionResult ViewCart(string softwareToPurchase)
        {
            List<string> softwareStrings = softwareToPurchase.Split(",").Where((s) => !string.IsNullOrEmpty(s)).ToList();
            List<Software> softwares = db.GetSoftwares(softwareStrings);
            ISession s = HttpContext.Session;
            string? username = s.GetString("username");
            PurchaseCart pc;
            if(username == null)
            {
                pc = new PurchaseCart();
            } else
            {
                pc = new PurchaseCart(username);
            }
            pc.softwareList = softwares;
            return View("ViewCart", pc);
        }

        public IActionResult PastPurchase()
        {
            ISession session = HttpContext.Session;
            string? username = session.GetString("username");
            if (username != null)
            {
                var purchases = db.GetPastPurchase2(username);

                return View(purchases);
            }
            return View();
        }
    }
}
