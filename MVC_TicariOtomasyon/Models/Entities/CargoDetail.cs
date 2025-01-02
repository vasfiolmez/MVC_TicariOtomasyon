using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Entities
{
    public class CargoDetail
    {
        public int CargoDetailId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string Description { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Personel { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Alıcı { get; set; }
        public DateTime Date { get; set; }
    }
}