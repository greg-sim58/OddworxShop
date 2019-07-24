using OddworxShop.Data.Models;
using System.Collections.Generic;

namespace OddworxShop.ViewModels
{
    public class ItemEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ItemCategory Category { get; set; }
        public int DefaultImage { get; set; }
        public bool IsActive { get; set; }

        public Shop Shop { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual List<Image> Images { get; set; }
    }
}