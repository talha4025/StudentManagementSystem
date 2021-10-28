using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using BusinessLayer.DataAccess;
using BusinessLayer.Utilities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace CrudTesting
{
    public class CreateTest
    {
        //const string connectionString= "Data Source=.;Initial Catalog=UnitTesting;Integrated Security=True";

        [Fact]
        public void Create_ShouldCreateRecord()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder("DataSource=:memory:");
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            var builder = new DbContextOptionsBuilder<OperationsContext>().UseSqlite(connection);
            Students student = new Students
            {
                FirstName = null,
                LastName = "Malik",
                Address = "Islamabad",
                ContactInfo = "",
                Department = "CS",
                Gender = null,
                CGPA = 0
            };

            ICRUD cRUD = new CRUD(builder.Options);
            cRUD.Create(student);

            var stud = cRUD.Search(1);
            Assert.NotNull(stud);

        }

        [Fact]
        public void Create_ShouldNotCreate()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder("DataSource=:memory:");
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            var builder = new DbContextOptionsBuilder<OperationsContext>().UseSqlite(connection);
            Students student = new Students
            {
                FirstName = null,
                LastName = "Malik",
                Address = "Islamabad",
                ContactInfo = "",
                Department = "CS",
                Gender = null,
                CGPA = 0
            };

            ICRUD cRUD = new CRUD(builder.Options);
            

            //var stud = cRUD.Search(1);
            Assert.False(cRUD.Create(student));
        }
    }
}
