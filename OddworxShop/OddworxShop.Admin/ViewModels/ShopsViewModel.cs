using OddworxShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OddworxShop.Admin.ViewModels
{
    public class ShopsViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Name of Shop")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Description of Shop")]
        public string Description { get; set; }

        [Required]
        [Display(Name="Contact Email")]
        public string ContactEmail { get; set; }

        [Required]
        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }

        [Display(Name = "Shop Website")]
        public string WebSite { get; set; }

        public User AdminUser { get; set; }

        public virtual ShopCategory Category { get; set; }
    }
}