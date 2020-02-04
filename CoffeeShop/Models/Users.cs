using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models
{
    public partial class Users
    {
        public Users()
        {
            UserItems = new HashSet<UserItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<UserItems> UserItems { get; set; }
    }
}
