using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class UserItemsController : Controller
    {
        private List<Items> itemList;
        private List<Users> userList;
        private List<UserItems> userItemList;
        private CoffeeShopContext db;

        public IActionResult Index()
        {
            CoffeeShopContext db = new CoffeeShopContext();

            //grab user items and add to a list
            //var userItems = db.UserItems.ToList();


            //db.UserItems.Add(new UserItems() { ItemId = 1, UserId = 3});
            //db.SaveChanges();
            return View();
        }

        public IActionResult List(UserItems userItemList)
        {
            
            return View(userItemList);
        }

        public IActionResult Details(Items itemlist)
        {
            //foreach item in itemList 
                //if (UserID == LoggedInUserID)
                    //return item;
            return View(itemList);
        }

        public IActionResult Delete(UserItems userItemList)
        {
            //delete function
                //Delete Row
                //Add cost of item back to user funds (Updating Database)
                //db.SaveChanges();
            return View();
        }
    }
}