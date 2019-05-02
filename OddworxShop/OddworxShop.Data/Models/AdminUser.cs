using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddworxShop.Data.Models
{
    public class AdminUser : Base
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid UniqueUserId { get; set; }
        public AdminUserRole AdminUserRole { get; set; }
    }
}