namespace ContosoUWebAPI.DAL
{
    using ContosoUWebAPI.Models;
    using Dapper;
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    /// <summary>
    /// This will be the Data Service for the Courses and all the CRUD operations
    /// that are associated with it
    /// </summary>
    public class CourseDataService : ICourseDataService
    {
        private readonly IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["ContosoUniRazorModel"].ConnectionString);

        /// <summary>
        /// Determines whether or not a course was deleted successfully
        /// </summary>
        /// <param name="courseId">The courseId to delete</param>
        /// <returns>A boolean</returns>
        public bool DeleteCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves all of the courses in the database
        /// </summary>
        /// <returns>List of all courses</returns>
        public List<Course> GetAllCourses()
        {
            return _db.Query<Course>("SELECT [CourseID],[Title],[Credits] FROM [Course]").ToList();
        }

        /// <summary>
        /// Adds a course to the database
        /// </summary>
        /// <param name="course">The course of interest</param>
        /// <returns>A boolean to let us know whether a course was added successfully</returns>
        public bool InsertCourse(Course course)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a course in the database
        /// </summary>
        /// <param name="course">The course to update</param>
        /// <returns>A boolean determining whether or not a course was updated</returns>
        public bool UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a single course from the database
        /// </summary>
        /// <param name="courseId">The course ID</param>
        /// <returns>Course</returns>
        public Course GetSingleCourse(int courseId)
        {
            try
            {
                return _db.Query<Course>("SELECT [CourseID],[Title],[Credits] FROM [Course] WHERE CourseID = @CourseID", 
                    new { CourseID = courseId }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred: " + ex.Message.ToString());
                return null;
            }
        }
    }
}