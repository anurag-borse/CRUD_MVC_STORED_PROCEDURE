using CRUD_MVC_STORED_PROCEDURE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_MVC_STORED_PROCEDURE.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }
        public DbSet<Employee> Employee { get; set; }

    }
}