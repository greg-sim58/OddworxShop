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

        [Display(Name="Contact Email")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ContactEmail { get; set; }

        [Required]
        [Display(Name = "Contact Phone")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string ContactPhone { get; set; }

        [Display(Name = "Shop Website")]
        public string WebSite { get; set; }

        public User AdminUser { get; set; }

        public virtual ShopCategory Category { get; set; }
    }
}