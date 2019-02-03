using OddworxShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddworxShop.ViewModels
{
    public class CreateShopViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string WebSite { get; set; }
        public User AdminUser { get; set; }

        public ShopCategory Category { get; set; }
    }
}