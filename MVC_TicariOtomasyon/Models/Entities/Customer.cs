using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Surname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Title { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string City { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Mail { get; set; }

        public ICollection<SalesMovement> SalesMovements { get; set; }
    }
}