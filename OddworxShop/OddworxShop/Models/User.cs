using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddworxShop.Models
{
    public class User : Base
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string AboutMe { get; set; }
        public string Location { get; set; }

        public virtual UserAccount Account { get; set; }
    }
}