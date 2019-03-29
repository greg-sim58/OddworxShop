using OddworxShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddworxShop.ViewModels
{
    public class ShopItemViewModel
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }

        public List<Item> Items { get; set; }
    }
}