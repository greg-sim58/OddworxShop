using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddworxShop.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string WebSite { get; set; }
        public User AdminUser { get; set; }

        public virtual ShopCategory Category { get; set; }
    }
}