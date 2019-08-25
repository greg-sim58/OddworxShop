using OddworxShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddworxShop.ViewModels
{
    public class ShowItemDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ItemCategory Category { get; set; }
        public int DefaultImage { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual List<Image> Images { get; set; }
    }
}