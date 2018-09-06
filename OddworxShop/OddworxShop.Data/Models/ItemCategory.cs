﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddworxShop.Data.Models
{
    public class ItemCategory :Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Parent { get; set; }
    }
}