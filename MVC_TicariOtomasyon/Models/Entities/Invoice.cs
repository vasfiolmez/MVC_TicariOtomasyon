using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceSerialNo{ get; set;}
        public string InvoiceSequenceNo { get; set;}
        public DateTime Date { get; set;}

        public string TaxOffice { get; set; }
        public DateTime Hour { get;set; }
        public string DelivereredBy { get; set; }
        public string ReceivedBy { get; set; }


    }
}