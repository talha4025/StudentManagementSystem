using BusinessLayer.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DataAccess
{
    public partial class OperationsContext : DbContext
    {
        private const string ConnectionString = "Data Source=.;Initial Catalog=TestDatabase;Integrated Security=True";
        //Configure database and set Student and Course tables
        public DbSet<Students> Student{ get; set; }
        public DbSet<Courses> Course { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=TestDatabase;Integrated Security=True");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public OperationsContext(DbContextOptions<OperationsContext> options) : base(options) { }

        public OperationsContext()
        {
        }
    }
}
