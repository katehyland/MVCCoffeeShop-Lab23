using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CoffeeShopContext db = new CoffeeShopContext();

            //grab user items and add to a list
            //var userItems = db.UserItems.ToList();

            //db.UserItems.Add(new UserItems() { ItemId = 1, UserId = 3});
            //db.SaveChanges();
            return View();
        }

        //need one action to load our RegistrationPage, also need a view
        public IActionResult RegistrationPage()
        {
            //if no view is specified it defaults to the Action Name
            return View();
        }

        // need one action to take those user inputs, and display the user name, in a new view
        public IActionResult Registered(
            RegistrationViewModel user)
        {
            CoffeeShopContext db = new CoffeeShopContext();
            db.Add(new Users()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone
            });
            db.SaveChanges();

            // use ViewBag to hold data to be displayed in the View
            ViewBag.UserName = user.Name;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
