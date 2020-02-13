using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Users
    {
        public Users()
        {
            UserItems = new HashSet<UserItems>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public decimal? Funds { get; set; }

        public virtual ICollection<UserItems> UserItems { get; set; }
    }
}
