using ContosoUWebAPI.Models;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ContosoUWebAPI.DAL
{
    /// <summary>
    /// This is the class that would be called through DI (dependency injection)
    /// at the time that the API controller calls for various actions
    /// </summary>
    public class StudentDataService : IStudentDataService
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["ContosoUniRazorModel"].ConnectionString);

        /// <summary>
        /// Deletes a student from the student table
        /// </summary>
        /// <param name="studentId">The id of the student</param>
        /// <returns>Whether or not the student record was successfully deleted</returns>
        public bool DeleteStudent(int studentId)
        {
            int rowsAffected = _db.Execute(@"DELETE FROM [Student] WHERE ID = @StudentId", new { StudentId = studentId });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets all the records in the student table
        /// </summary>
        /// <returns>A list of students</returns>
        public List<Student> GetAllStudents()
        {
            return _db.Query<Student>("SELECT [ID], [LastName], [FirstMidName], [EnrollmentDate] FROM [Student]").ToList(); 
        }

        /// <summary>
        /// Returns a single student record
        /// </summary>
        /// <param name="studentId">The id of the student</param>
        /// <returns>A single record as the result of a SELECT...WHERE statement in SQL</returns>
        public Student GetSingleStudent(int studentId)
        {
            return _db.Query<Student>("SELECT [ID], [LastName], [FirstMidName], [EnrollmentDate] FROM [Student] WHERE ID = @ID", 
                new { ID = studentId }).FirstOrDefault();
        }

        /// <summary>
        /// Adds a student to the student table
        /// </summary>
        /// <param name="student">The student object</param>
        /// <returns>A boolean to determine whether or not the student was successfully added</returns>
        public bool InsertStudent(Student student)
        {
            int rowsAffected = this._db.Execute(@"INSERT Student([LastName],[FirstMidName], [EnrollmentDate]) 
                                                values (@StudentLastName, @StudentFirstMidName, @EnrollDate)", 
                new
                {
                    StudentLastName = student.LastName,
                    StudentFirstMidName = student.FirstMidName,
                    EnrollDate = student.EnrollmentDate
                });

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates an exisiting student record
        /// </summary>
        /// <param name="student">The student object</param>
        /// <returns>A boolean to determine whether or not the student was successfully updated</returns>
        public bool UpdateStudent(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}