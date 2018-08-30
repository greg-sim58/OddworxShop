﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddworxShop.Models
{
    public class Item : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ItemCategory Category { get; set; }
        public Image Image { get; set; }
        public virtual List<Rating> Ratings { get; set; }
    }
}