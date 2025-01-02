using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Entities
{
    public class CargoTracking
    {
        public int CargoTrackingId { get; set; }

        [Column(TypeName ="VarChar")]
        [StringLength(10)]

        public string TrackingCode { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(100)]

        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}