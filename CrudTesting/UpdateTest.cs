using BusinessLayer.DataAccess;
using BusinessLayer.Utilities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CrudTesting
{
    public class UpdateTest
    {
        [Fact]
        public void Update_ShouldUpdateRecord()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder("DataSource=:memory:");
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            var builder = new DbContextOptionsBuilder<OperationsContext>().UseSqlite(connection);
            Students student = new Students
            {
                FirstName = "Ali",
                LastName = "Malik",
                Address = "Islamabad",
                ContactInfo = "2342342423434",
                Department = "CS",
                Gender = "Male",
                CGPA = 0
            };

            ICRUD cRUD = new CRUD(builder.Options);
            cRUD.Create(student);

            student.Department = "EE";

            //var stud = cRUD.Search(1);
            Assert.True(cRUD.Update(student));

        }
        [Fact]
        public void Update_ShouldNotUpdateRecord()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder("DataSource=:memory:");
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            var builder = new DbContextOptionsBuilder<OperationsContext>().UseSqlite(connection);
            Students student = new Students
            {
                FirstName = "Ali",
                LastName = "Malik",
                Address = "Islamabad",
                ContactInfo = "2342342423434",
                Department = "CS",
                Gender = "Male",
                CGPA = 0
            };

            ICRUD cRUD = new CRUD(builder.Options);
            cRUD.Create(student);

            student.FirstName = null;

            //var stud = cRUD.Search(1);
            Assert.False(cRUD.Update(student));

        }
    }
}
