using BusinessLayer.Utilities;
using System.Collections.Generic;

namespace BusinessLayer
{
    // <summary>
    // Interface for methods to communicate between business layer and UI
    // <summary>
    public interface IBusinessLogic
    {
        void AddCourse(Courses course);
        void create(Students student);
        void Delete(int Id);
        List<Students> getAll();
        Students search(int Id);
        void update(Students student);
    }
}