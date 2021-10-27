using BusinessLayer;
using BusinessLayer.Utilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

// <summary>
// Base UI class
// </summary>

namespace StudentManageSystem
{
    class Application : IApplication
    {
        IBusinessLogic _businessLogic;
        ILogInfo _logger;
       
        public Application(IBusinessLogic businessLogic,ILogInfo logger)
        {
            _businessLogic = businessLogic;
            _logger = logger;
        }

        public void Run()
        {

            _logger.Log($"Logged at { DateTime.Now}");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\t\t\t\t\tWelcome to Student Management System\n\n");
                Console.WriteLine("\t\t\t\t\t\t1. Add Student");
                Console.WriteLine("\t\t\t\t\t\t2. Update Student Details ");
                Console.WriteLine("\t\t\t\t\t\t3. Search Student by ID");
                Console.WriteLine("\t\t\t\t\t\t4. Show all students ");
                Console.WriteLine("\t\t\t\t\t\t5. Delete student by ID\n");

                Console.WriteLine("\t\t\t\t\t\t6. Add a Course to student profile\n");
                Console.Write("\t\t\t\t\tSelect an option to continue or q to Quit: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Create();
                        break;
                    case "2":
                        Update();
                        break;
                    case "3":
                        Search();
                        break;
                    case "4":
                        ShowAll();
                        break;
                    case "5":
                        Delete();
                        break;
                    case "6":
                        AddCourse();
                        break;
                    case "q":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Input\n");
                        break;
                }
            }
        }
        private void Create()
        {
            bool input = true;
            Console.Clear();
            Students student = TakeInput();
            _businessLogic.create(student);
            Console.WriteLine("Added");
            _logger.Log("-> Student added to database");
            while (input)
            {
                if (MainMenuReturn() == true)
                {
                    input = false;
                }
            }
            Console.Clear();
        }
        private void Delete()
        {
            bool input = true;
            Console.Clear();

            Console.Write("Enter ID to Delete: ");
            try
            {
                int id = Int32.Parse(Console.ReadLine());
                string details = GetAllProperties(_businessLogic.search(id));

                if (details != null)
                {
                    Console.WriteLine("\n\n" + details + "\n\n");
                    _businessLogic.Delete(id);
                    Console.WriteLine(" -> Student Deleted\n");
                    _logger.Log("Student deleted from database");
                }
                else
                {
                    Console.WriteLine("No Students Found in Database");
                    _logger.Log("Error: student not found in database");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please Enter Only Number for ID");
                _logger.Log(ex.Message);
            }
            while (input)
            {
                if (MainMenuReturn() == true)
                {
                    input = false;
                }
            }
            Console.Clear();
        }
        private void ShowAll()
        {
            bool input=true;
            List<Students> student = _businessLogic.getAll();
            Console.Clear();
            
            if (student.Count != 0)
            {
                foreach (Students st in student)
                {
                    Console.WriteLine(GetAllProperties(st) + "\n");
                }
                _logger.Log("Students displayed on Console");
            }
            else
            {
                Console.WriteLine("No Students Found in Database");
                _logger.Log("No Students Found in Database");
            }
            while (input)
            {
                if (MainMenuReturn() == true)
                {
                    input = false;
                }
            }
            Console.Clear();
        }
        private void Search()
        {
            bool input = true;
            Console.Clear();
            Console.Write("Enter ID to Search: ");
            try
            {
                int id = Int32.Parse(Console.ReadLine());
                string details = GetAllProperties(_businessLogic.search(id));

                if (details != null)
                {
                    Console.WriteLine("\n\n" + details + "\n\n");
                    _logger.Log("Student Searched in database by ID");
                }
                else
                {
                    Console.WriteLine("No Students Found in Database");
                    _logger.Log("Error: student not found in database");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please Enter Only Number for ID");
                _logger.Log(ex.Message);
            }
            while (input)
            {
                if (MainMenuReturn() == true)
                {
                    input = false;
                }
            }

            Console.Clear();
        }
        private void Update()
        {
            Console.Clear();
            bool updated = false;
            bool input = true;
            Students student = null;
            while (updated == false)
            {
                try
                {
                    int id = Int32.Parse(Console.ReadLine());
                    string details = GetAllProperties(_businessLogic.search(id));

                    if (details != null)
                    {
                        Console.WriteLine("\n\n" + details + "\n\n");
                        student = TakeInput();
                        student.Id = id;
                        _businessLogic.update(student);
                        updated = true;
                        _logger.Log("Student Details updated in database");
                        Console.WriteLine("Student Updated");
                    }
                    else
                    {
                        Console.WriteLine("No Students Found in Database");
                        _logger.Log("Error: student not found in database");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please Enter Only Number for ID");
                    _logger.Log(ex.Message);
                }

            }
            while (input)
            {
                if (MainMenuReturn() == true)
                {
                    input = false;
                }
            }
            Console.Clear();
        }

        private void AddCourse()
        {
            Console.Clear();
            bool added = false;
            bool input = true;
            while (added == false)
            {
                Console.Write("Enter Student ID to Add Course: ");
                int id = Int32.Parse(Console.ReadLine());
                string details = GetAllProperties(_businessLogic.search(id));

                if (details != null)
                {
                    Courses courseDetails = null;
                    Console.WriteLine("\n\n" + details + "\n\n");
                    Console.WriteLine("\n!!!Enter Course Details for Selected Student!!!\n");
                    courseDetails = TakeCourseInput();
                    courseDetails.StudentId= id;
                    _businessLogic.AddCourse(courseDetails);
                    added = true;
                    _logger.Log("Course added to Student profile in database");
                    Console.WriteLine("Course added to Student profile in database");
                }
                else
                {
                    Console.WriteLine("No Students Found in Database");
                    _logger.Log("Error: student not found in database to add Course");
                }
            }
            while (input)
            {
                if (MainMenuReturn() == true)
                {
                    input = false;
                }
            }
            Console.Clear();
        }

        private Courses TakeCourseInput()
        {
            Courses course = new Courses();
            bool input = true;
            while (input)
            {
                Console.Write("\nEnter Course Name: ");
                course.CourseName= Console.ReadLine();
                Console.Write("\nEnter Grade Point(0-4): ");
                course.GradePoint = float.Parse(Console.ReadLine());
                Console.Write("\nEnter Credit Hours Point(0-3): ");
                course.CreditHours = Int32.Parse(Console.ReadLine());

                var result = new List<ValidationResult>();
                bool IsValid = Validator.TryValidateObject(course, new ValidationContext(course), result, true);
                if (IsValid == true)
                {
                    input = false;
                }
                else
                {
                    Console.WriteLine("\n\n");
                    foreach (var message in result)
                    {
                        Console.WriteLine(message.ErrorMessage);
                    }
                    _logger.Log("Invalid Input by user");
                    Console.WriteLine("\n\n!!!Enter valid details again!!!");
                }
            }
            return course;

        }
        private Students TakeInput()
        {
            bool input = true;
            Students student = new Students();
            while (input)
            {   
                Console.Write("\nEnter First Name: ");
                student.FirstName = Console.ReadLine();
                Console.Write("\nEnter Last Name: ");
                student.LastName = Console.ReadLine();
                Console.Write("\nEnter Department: ");
                student.Department = Console.ReadLine();
                Console.Write("\nEnter Address: ");
                student.Address = Console.ReadLine();
                Console.Write("\nEnter Contact Info: ");
                student.ContactInfo = Console.ReadLine();
                Console.Write("\nEnter Gender(Male or Female): ");
                student.Gender = Console.ReadLine();

                var result = new List<ValidationResult>();
                bool IsValid =Validator.TryValidateObject(student,new ValidationContext(student),result,true);
                if (IsValid==true)
                {
                    input = false;
                }
                else
                {
                    Console.WriteLine("\n\n");
                    foreach (var message in result)
                    {
                        Console.WriteLine(message.ErrorMessage);
                    }
                    _logger.Log("Invalid Input by user");
                    Console.WriteLine("\n\n!!!Enter valid details again!!!");
                }
            }
            return student;
        }


        public static string GetAllProperties(Students obj)
        {
            string studentDetails = null;
            if (obj == null || obj.Id == 0 )
            {
                return studentDetails;
            }
            else
            {
                studentDetails = ($"Student Id: {obj.Id} \nFirst Name: {obj.FirstName} \nLast Name: {obj.LastName}" +
                    $" \nDepartment: {obj.Department} \nContact: {obj.ContactInfo} \nAddress: {obj.Address} \nGender: {obj.Gender} \nCGPA: {obj.CGPA}");

            }
            return studentDetails;
        }
        private bool MainMenuReturn()
        {
            bool input = false;
            Console.Write("Enter Q to return to Main Menu: ");
            switch (Console.ReadLine().ToUpper())
            {
                case "Q":
                    input = true;
                    break;
                default:
                    Console.WriteLine("Invalid Input\n");
                    break;
            }
            return input;
        }
        
    }
}
