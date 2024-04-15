using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewCart()
        {
            return View();
        }

        public IActionResult PastPurchase()
        {
            return View();
        }
    }
}
