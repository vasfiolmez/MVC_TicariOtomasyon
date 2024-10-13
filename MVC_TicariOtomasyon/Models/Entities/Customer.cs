using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } 
        public string Title { get; set; } 
        public string City { get; set; } 
        public string Mail { get; set; } 
    }
}