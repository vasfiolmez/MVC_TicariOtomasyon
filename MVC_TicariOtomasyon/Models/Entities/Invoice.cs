using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialNo{ get; set;}

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceSequenceNo { get; set;}
        public DateTime Date { get; set;}

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxOffice { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string Hour { get;set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DelivereredBy { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ReceivedBy { get; set; }

        public decimal Toplam { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }


    }
}