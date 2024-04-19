using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Models.EF;

namespace ShoppingCart.Controllers
{
    public class LoginController : Controller
    {
        private readonly DatabaseContext db;
        
        public LoginController(DatabaseContext db) {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Response.Cookies.Delete("SessionId");
            ViewData["sessionId"] = null;
            return View();
        }

        [HttpPost]
        public IActionResult Index(PurchaseCart pc)
        {
            return View(pc);
        }

        public IActionResult Login(string username, string password)
        {
            User? user = db.Login(username, password);
            if (user != null)
            {
                return StartSession(user);
            }
            return View("Index", new LoginResult("Log in failed."));
        }

        public IActionResult StartSession(User user)
        {
            string sessionId = System.Guid.NewGuid().ToString();
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append("SessionId", sessionId, options);
            HttpContext.Session.SetString("username", user.username);
            if(HttpContext.Session.Keys.Contains("checking-out"))
            {
                return RedirectToAction("Checkout", "Software");
            }

            return RedirectToAction("Index", "Software", user);
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("SessionId");
            HttpContext.Session.Clear();
            ViewData["username"] = null;
            return View("Index");
        }

        
    }

    public class LoginResult
    {
        public string result { get; set; } = "";

        public LoginResult(string res)
        {
            this.result = res;
        }
    }
}
