using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace OddworxShop.Data.DAL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=OddworxShopContext")
        {
        }

        public System.Data.Entity.DbSet<OddworxShop.Data.Models.UserAccountType> UserAccountTypes { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Data.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Data.Models.ShopCategory> ShopCategories { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Data.Models.Shop> Shops { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Data.Models.Rating> Ratings { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Data.Models.ItemCategory> ItemCategories { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Data.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<OddworxShop.Data.Models.Image> Images { get; set; }
        public System.Data.Entity.DbSet<OddworxShop.Data.Models.AdminUser> AdminUser { get; set; }
        public System.Data.Entity.DbSet<OddworxShop.Data.Models.AdminUserRole> AdminUserRole { get; set; }

        
    }
}