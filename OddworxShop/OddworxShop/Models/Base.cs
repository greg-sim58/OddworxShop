using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OddworxShop.Models
{
    public class Base
    {
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public int LastModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}