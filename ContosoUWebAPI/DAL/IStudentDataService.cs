using ContosoUWebAPI.Models;
using System.Collections.Generic;

namespace ContosoUWebAPI.DAL
{
    /// <summary>
    /// This is to be making sure that all of the StudentDataService methods
    /// are being defined.  Implementation is defined in the StudentDataService
    /// class.
    /// </summary>
    public interface IStudentDataService
    {
        List<Student> GetAllStudents();
        Student GetSingleStudent(int studentId);
        bool InsertStudent(Student student);
        bool DeleteStudent(int studentId);
        bool UpdateStudent(Student student);
    }
}
