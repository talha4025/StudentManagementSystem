using BusinessLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    // <summary>
    // Injector class to communicate between business layer and UI
    // <summary>

    public class BusinessLogic : IBusinessLogic
    {
        ICRUD _operations;

        public BusinessLogic(ICRUD operations)
        {
            _operations = operations;
        }

        public void create(Students student)
        {
            _operations.Create(student);
        }
        public void update(Students student)
        {
            _operations.Update(student);
        }
        public Students search(int Id)
        {
            return _operations.Search(Id);
        }
        public List<Students> getAll()
        {
            return _operations.GetAll();
        }
        public void Delete(int Id)
        {
            _operations.Delete(Id);
        }

        //Add Course to course table and update student cgpa based on registerd courses
        public void AddCourse(Courses course)
        {
            _operations.AddCourse(course);
            _operations.UpdateCgpa(course.StudentId);
        }
    }
}
