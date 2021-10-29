using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.DataAccess;
using BusinessLayer.Utilities;

namespace CrudTesting
{
    public class GetAllTest
    {
        [Fact]
        public void GetAll_ShouldRetrieveRecords()
        {
            var connectionStringBuilder=new SqliteConnectionStringBuilder("DataSource=:memory:");
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            connection.Open();
            var builder = new DbContextOptionsBuilder<OperationsContext>().UseSqlite(connection);
            var options = builder.Options;

            //Students student = new Students
            //{
            //    FirstName = "Ali",
            //    LastName = "Malik",
            //    Address = "Islamabad",
            //    ContactInfo = "2342342423434",
            //    Department = "CS",
            //    Gender = "Male",
            //    CGPA = 0
            //};

            ICRUD cRUD = new CRUD(options);
            //cRUD.Create(student);

            Assert.NotEmpty(cRUD.GetAll());
            connection.Dispose();


        }
    }
}
