using System.Collections.Generic;

namespace BusinessLayer.Utilities
{
    // <summary>
    // Interface for Students and Courses related business logic methods
    // </summary>
    public interface ICRUD
    {
        void AddCourse(Courses course);
        bool Create(Students student);
        void Delete(int Id);
        List<Students> GetAll();
        Students Search(int Id);
        bool Update(Students student);
        void UpdateCgpa(int studentId);
    }
}