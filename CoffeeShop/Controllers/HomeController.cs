using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using CoffeeShop.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace CoffeeShop.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }

    public class HomeController : Controller
    {
       
        private List<Items> itemList;
        private List<Users> userList;
        private ShopDbContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Actions

        private void GetData()
        {
            itemList = db.Items.ToList();
            userList = db.Users.ToList();
        }

        public IActionResult Transaction(decimal itemPrice, int quantity, string name)
        {
            ShopDbContext db = new ShopDbContext();
            List<AspNetUsers> userList = db.AspNetUsers.ToList();
            List<Items> itemList = db.Items.ToList();

            foreach (Items item in itemList)
            {
                if (item.Name == name)
                {
                    item.Quantity = quantity;
                    db.SaveChanges();
                }
            }

            foreach (AspNetUsers user in userList)
            {
                if (user.Email == User.Identity.Name)
                {
                    if (user.Funds >= itemPrice)
                    {
                        user.Funds -= itemPrice;
                        db.AspNetUsers.Update(user);
                        db.SaveChanges();

                        return View("TransactionSuccess", db);
                    }

                }
            }
                    return View("TransactionError", db);
        }
        public IActionResult Registered(Users user)
        {
            ShopDbContext db = new ShopDbContext();
            _ = db.Add(new Users()
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Funds = 10
            }); ;
            db.SaveChanges();

            HttpContext.Session.SetObjectAsJson("loggedInUser", user);

            return View("ShopPage");
        }

        //Views
        public IActionResult RegistrationPage()
        {
            return View();
        }

        public IActionResult Index()
        {
            ShopDbContext db = new ShopDbContext();

            //grab user items and add to a list
            //var userItems = db.UserItems.ToList();


            //db.UserItems.Add(new UserItems() { ItemId = 1, UserId = 3});
            db.SaveChanges();
            return View();
        }

        public IActionResult TransactionSuccess() {

            return View();
        }

        public IActionResult TransactionError(UserItems userItem)
        {
            string itemName = userItem.Item.Name;
            string itemDescription = userItem.Item.Description;
            decimal itemPrice = userItem.Item.Price;
            decimal? funds = userItem.User.Funds;

            ViewBag.ItemName = itemName;
            ViewBag.ItemPrice = itemPrice;
            ViewBag.UserFunds = funds;
            ViewBag.ItemDescription = itemDescription;
            
            return View();
        }

        public IActionResult ShopPage(U)
        {

            ShopDbContext db = new ShopDbContext();

            return View(db);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
