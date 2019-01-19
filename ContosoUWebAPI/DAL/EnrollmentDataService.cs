namespace ContosoUWebAPI.DAL
{
    using ContosoUWebAPI.Models;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// All CRUD operations for the enrollments
    /// </summary>
    public class EnrollmentDataService : IEnrollmentDataService
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["ContosoUniRazorModel"].ConnectionString);

        /// <summary>
        /// Deletes an enrollment
        /// </summary>
        /// <param name="enrollmentId">Enrollment ID to delete</param>
        /// <returns>A boolean</returns>
        public bool DeleteEnrollment(int enrollmentId)
        {
            int rowsAffected = _db.Execute(@"DELETE FROM [Course] WHERE EnrollmentID = @EnrollmentId",
                new
                {
                    EnrollmentId = enrollmentId
                });
            return rowsAffected > 0;
        }

        /// <summary>
        /// Gets all enrollments
        /// </summary>
        /// <returns>List of enrollments</returns>
        public List<Enrollment> GetAllEnrollments()
        {
            return _db.Query<Enrollment>("SELECT [EnrollmentID], [CourseID], [StudentID], [Grade] FROM [Enrollment]").ToList();
        }

        /// <summary>
        /// Adds a new enrollment
        /// </summary>
        /// <param name="enrollment">The object (or enrollment) to be added</param>
        /// <returns>A boolean determining whether records are added or not</returns>
        public bool InsertEnrollment(Enrollment enrollment)
        {
            int rowsAffected = _db.Execute(@"INSERT Enrollment([CourseID], [StudentID], [Grade]) VALUES (@CourseId, @StudentID, @Grade)", 
                new
                {
                    CourseId = enrollment.CourseID, 
                    StudentId = enrollment.StudentID,
                    enrollment.Grade
                });
            return rowsAffected > 0;
        }

        /// <summary>
        /// Updates an enrollment
        /// </summary>
        /// <param name="enrollment">The enrollment record to be updated</param>
        /// <returns>A boolean determining whether or not the record was updated</returns>
        public bool UpdateEnrollment(Enrollment enrollment)
        {
            int rowsAffected = _db.Execute("UPDATE [Enrollment] SET [CourseID] = @courseId ,[StudentID] = @studentId WHERE EnrollmentID = " + enrollment.EnrollmentID, enrollment);
            return rowsAffected > 0;
        }

        /// <summary>
        /// The ability to get a single enrollment record
        /// </summary>
        /// <param name="enrollmentId">The enrollment Id (the primary key)</param>
        /// <returns>A single record</returns>
        public Enrollment GetSingleEnrollment(int enrollmentId)
        {
            try
            {
                return _db.Query<Enrollment>("SELECT [EnrollmentID], [CourseID], [StudentID], [Grade] FROM [Enrollment] WHERE EnrollmentID = @EnrollmentID",
                    new { EnrollmentID = enrollmentId }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("There was an error that occurred: " + ex.Message.ToString());
                return null;
            }
        }
    }
}