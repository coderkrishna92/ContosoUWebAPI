namespace ContosoUWebAPI.DAL
{
    using ContosoUWebAPI.Models;
    using System.Collections.Generic;

    /// <summary>
    /// This is to be making sure that all of the StudentDataService methods
    /// are being defined.  Implementation is defined in the StudentDataService
    /// class.
    /// </summary>
    public interface IStudentDataService
    {
        /// <summary>
        /// Method to get all the students
        /// </summary>
        List<Student> GetAllStudents();

        /// <summary>
        /// Method that will return a single student given a student id.
        /// </summary>
        Student GetSingleStudent(int studentId);

        /// <summary>
        /// Adds a student to the database
        /// </summary>
        /// <param name="student">Student to add to the database</param>
        bool InsertStudent(Student student);

        /// <summary>
        /// Deletes a student from the database
        /// </summary>
        /// <param name="studentId">The Student Id to use for deletion</param>
        bool DeleteStudent(int studentId);

        /// <summary>
        /// Updates a student in the database
        /// </summary>
        /// <param name="student">Student to update</param>
        bool UpdateStudent(Student student);
    }
}