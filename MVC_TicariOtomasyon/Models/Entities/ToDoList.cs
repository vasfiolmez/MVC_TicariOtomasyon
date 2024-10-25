using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Models.Entities
{
    public class ToDoList
    {
        public int ToDoListId { get; set; }
        public string Baslik { get; set; }
        public bool Status { get; set; }
    }
}