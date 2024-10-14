using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Entities
{
    public class SalesMovement
    {
        public int SalesMovementId { get; set; }

        public DateTime Date { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }


        public Product Product{ get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
        
    }
}