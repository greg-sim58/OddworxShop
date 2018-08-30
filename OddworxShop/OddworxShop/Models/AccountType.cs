﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddworxShop.Models
{
    public class AccountType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PaymentFrequency { get; set; }
    }
}