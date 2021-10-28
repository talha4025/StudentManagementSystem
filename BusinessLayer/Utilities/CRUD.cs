using BusinessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Utilities
{
    // <summary>
    // Implementation for Students and Courses related business logic methods
    // <summary>
    public class CRUD : ICRUD
    {
        OperationsContext context;
        public CRUD()
        {
            context = new OperationsContext();
        }
        public CRUD(DbContextOptions<OperationsContext> options)
        {
            context = new OperationsContext(options);
            context.Database.EnsureCreated();
        }

        //Create a new record in databse
        public bool Create(Students student)
        {
            try
            {
                context.Student.Add(student);
                context.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }


        //Update an existing record in database
        public void Update(Students student)
        {
            Students _student = null;
            _student = context.Student.Where(s => s.Id == student.Id).FirstOrDefault<Students>();
            if (_student != null)
            {
                _student.FirstName = student.FirstName;
                _student.LastName = student.LastName;
                _student.Gender = student.Gender;
                _student.Address = student.Address;
                _student.ContactInfo = student.ContactInfo;
                _student.Department = student.Department;
                context.Entry<Students>(_student).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        //Search a record in database by ID and return a student object
        public Students Search(int Id)
        {
            Students student = null;
            student = context.Student.Where(s => s.Id == Id).FirstOrDefault<Students>();
            return student;
        }

        //Retreive all student records from database and return List of student objects
        public List<Students> GetAll()
        {
            List<Students> students = null;
            students = context.Student.ToList<Students>();
            return students;
        }

        //Delete a student from database by ID
        //Also deletes courses related to student in Course table by studentId foreign key
        public void Delete(int Id)
        {
            Students student = null;
            student = context.Student.Where(s => s.Id == Id).FirstOrDefault<Students>();
            if (student != null)
            {
                context.Entry<Students>(student).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        //Add course for an existing student in database
        public void AddCourse(Courses course)
        {
            context.Course.Add(course);
            context.SaveChanges();
        }

        //Update cgpa in Student table when a course is added to Course table
        public void UpdateCgpa(int studentId)
        {

            //Multiplying each Grade Point and Credit hours from each row and dividing its sum by sum of total credit hours
            var totalPoints = context.Course.Where(x => x.StudentId == studentId).Sum(t => t.GradePoint * t.CreditHours);
            var totalCredits = context.Course.Where(x => x.StudentId == studentId).Sum(t => t.CreditHours);

            var student = context.Student.Find(studentId);
            var cgpa = (totalPoints / totalCredits).ToString("0.00");
            student.CGPA =float.Parse(cgpa);
            context.Student.Update(student);
            context.SaveChanges();
            
        }

    }
}
