using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}