namespace ContosoUWebAPI.DAL
{
    using ContosoUWebAPI.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The ICourseDataService will contain the method definitions, and the implementation of 
    /// each method is contained in the CourseDataService class
    /// </summary>
    public interface ICourseDataService
    {
        /// <summary>
        /// GetAllCourses
        /// </summary>
        /// <returns>Returns the list of all courses</returns>
        List<Course> GetAllCourses();

        /// <summary>
        /// Adds a course to the database
        /// </summary>
        /// <param name="course">The course to be added</param>
        /// <returns>A boolean value to determine whether or not the course was added successfully</returns>
        bool InsertCourse(Course course);

        /// <summary>
        /// Deletes a course from the database
        /// </summary>
        /// <param name="courseId">The courseId specified</param>
        /// <returns>A boolean to say whether or not the course was deleted successfully</returns>
        bool DeleteCourse(int courseId);

        /// <summary>
        /// Updates a course that already exists in the database
        /// </summary>
        /// <param name="course">The course entity to update</param>
        /// <returns>A boolean value to say whether or not a course was updated successfully</returns>
        bool UpdateCourse(Course course);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Course GetSingleCourse(int courseId);
    }
}