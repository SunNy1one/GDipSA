﻿using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            Response.Cookies.Delete("SessionId");
            ViewData["sessionId"] = null;
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            
            if (ShoppingCart.Models.User.Login(username, password) == LoginStatus.Success)
            {
                return StartSession();
            }
            return Json(new {result = "Log in failed."});
        }

        public IActionResult StartSession()
        {
            string sessionId = System.Guid.NewGuid().ToString();
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append("SessionId", sessionId, options);
            return RedirectToAction("Index", "Software");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("SessionId");
            return RedirectToAction("Index");
        }
    }
}
