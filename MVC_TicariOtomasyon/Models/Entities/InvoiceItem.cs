using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Entities
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public string Description { get; set; }
        public int Piece { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}