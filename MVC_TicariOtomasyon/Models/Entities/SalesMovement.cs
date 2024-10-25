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
        public decimal? Amount { get; set; }

        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public virtual Product Product{ get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        
    }
}