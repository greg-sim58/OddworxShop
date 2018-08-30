using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddworxShop.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual AccountType AccountType { get; set; }
    }
}