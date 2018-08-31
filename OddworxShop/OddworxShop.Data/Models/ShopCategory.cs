using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddworxShop.Data.Models
{
    public class ShopCategory : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}