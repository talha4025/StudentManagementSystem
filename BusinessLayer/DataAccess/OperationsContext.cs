using BusinessLayer.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DataAccess
{
    public partial class OperationsContext : DbContext
    {
        //Configure database and set Student and Course tables
        public DbSet<Students> Student{ get; set; }
        public DbSet<Courses> Course { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=TestDatabase;Integrated Security=True");
        }
    }
}
