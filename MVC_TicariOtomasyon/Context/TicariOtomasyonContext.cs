using MVC_TicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_TicariOtomasyon.Context
{
    public class TicariOtomasyonContext:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesMovement> SalesMovements { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
    }
}