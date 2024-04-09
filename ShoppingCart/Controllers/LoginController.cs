using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            if(ShoppingCart.Models.User.Login(username, password) == LoginStatus.Success)
            {
                return RedirectToAction("Index", "Software");
            }
            return Json(new {result = "Log in failed."});
        }
    }
}
