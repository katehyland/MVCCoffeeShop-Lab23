﻿using System;
using System.Collections.Generic;

namespace CoffeeShop.Models
{
    public partial class Items
    {
        public Items()
        {
            UserItems = new HashSet<UserItems>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }

        public virtual ICollection<UserItems> UserItems { get; set; }
    }
}
