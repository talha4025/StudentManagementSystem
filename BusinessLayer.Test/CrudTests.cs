using Autofac.Extras.Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BusinessLayer;
using BusinessLayer.DataAccess;
using BusinessLayer.Utilities;

namespace BusinessLayer.Test
{
    public class CrudTests
    {

        [Fact]
        /*public void Create_ShouldCreate()
        {
            
        }*/

        private Students GetSampleStudents()
        {
            Students students = new Students
            {
                FirstName = "Talha",
                LastName = "Malik",
                Gender = "Male",
                Address = "Islamabad",
                ContactInfo = "03111111111",
                Department = "CS"
            };
            /*List<Students> students = new List<Students>()
            {
                new Students
                {
                    FirstName = "Talha",
                    LastName = "Malik",
                    Gender = "Male",
                    Address = "Islamabad",
                    ContactInfo = "03111111111",
                    Department = "CS"
                },
                new Students
                {
                    FirstName = "Asfand",
                    LastName = "Malik",
                    Gender = "Male",
                    Address = "Lahore",
                    ContactInfo = "+923111111111",
                    Department = "CS"
                },
                new Students
                {
                    FirstName = "Talha",
                    LastName = "Malik",
                    Gender = "Male",
                    Address = "Karachi",
                    ContactInfo = "03111111111",
                    Department = "SE"
                }
                
            };*/

            return students;
        }
    }
}
