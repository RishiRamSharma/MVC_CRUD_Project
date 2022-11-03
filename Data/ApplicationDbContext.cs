using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCnewProject.Models;

namespace MVCnewProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("contstr")
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}