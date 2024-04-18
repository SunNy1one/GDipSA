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


        
    }
}
