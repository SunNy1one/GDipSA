using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Models.EF;

namespace ShoppingCart.Controllers
{
    public class LoginController : Controller
    {
        private readonly DatabaseContext db;
        private readonly MyDbContext mydb;
        
        public LoginController(DatabaseContext db, MyDbContext mydb) {
            this.db = db;
            this.mydb = mydb;
            
        }
        public IActionResult Index()
        {
            Response.Cookies.Delete("SessionId");
            ViewData["sessionId"] = null;
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            string? userId = db.Login(username, password);
            if (userId != null)
            {
                return StartSession(username, userId);
            }
            return View("Index", new LoginResult("Log in failed."));
        }

        public IActionResult StartSession(string username, string userId)
        {
            string sessionId = System.Guid.NewGuid().ToString();
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append("SessionId", sessionId, options);
            ISession session = HttpContext.Session;
            session.SetString("username", username);
            session.SetString("userId", userId);
            return RedirectToAction("Index", "Software");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("SessionId");
            return RedirectToAction("Index");
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
