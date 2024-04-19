using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //starting from the receiving the list of confirmed purchases from the cart page
        public IActionResult ReceivePurchases(List<Purchase> purchases)
        {
            ViewBag.purchases = purchases;  
            return View();
        }

        public IActionResult GoToGallary()
        {
            return RedirectToAction("Index", "Software");
        }

        public IActionResult LogOut()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
