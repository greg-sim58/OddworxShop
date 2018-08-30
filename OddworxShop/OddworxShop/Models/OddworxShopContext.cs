using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OddworxShop.Models
{
    public class OddworxShopContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OddworxShopContext() : base("name=OddworxShopContext")
        {
        }

        public System.Data.Entity.DbSet<OddworxShop.Models.UserAccount> UserAccounts { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Models.Image> Images { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Models.ItemCategory> ItemCategories { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Models.Rating> Ratings { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Models.Shop> Shops { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Models.ShopCategory> ShopCategories { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Models.UserAccountType> UserAccountTypes { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Models.User> Users { get; set; }
    }
}
