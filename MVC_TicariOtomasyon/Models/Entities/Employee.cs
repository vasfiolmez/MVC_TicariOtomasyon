﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Surname { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public ICollection<SalesMovement> SalesMovements { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}