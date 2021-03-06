﻿namespace ContosoUWebAPI.Controllers
{
    using ContosoUWebAPI.DAL;
    using ContosoUWebAPI.Models;
    using System.Web.Http;

    /// <summary>
    /// This is the student controller
    /// </summary>
    public class StudentsController : ApiController
    {
        private static IStudentDataService _studentDataService { get; set; }

        /// <summary>
        /// Constructor for the controller
        /// </summary>
        /// <param name="studentDataService">The student data service to make the attempt for having the necessary 
        /// IoC/Factory pattern being used</param>
        public StudentsController(IStudentDataService studentDataService)
        {
            _studentDataService = studentDataService;
        }

        /// <summary>
        /// This is the controller method that would add a student to the database
        /// </summary>
        /// <param name="student">The student to add</param>
        /// <returns>A boolean to determine whether or not the student was added successfully</returns>
        [Route("api/Students/Add")]
        [HttpPost]
        public bool AddStudent(Student student)
        {
            return _studentDataService.InsertStudent(student); 
        }

        /// <summary>
        /// This is the controller method that would delete a student from the database.
        /// </summary>
        /// <param name="studentId">The studentId that is to be deleted</param>
        /// <returns>A boolean to find out whether or not a student was deleted</returns>
        [Route("api/Students/Delete")]
        public bool DeleteStudent(int studentId)
        {
            return _studentDataService.DeleteStudent(studentId); 
        }

        /// <summary>
        /// Controller method to get the single student
        /// </summary>
        /// <param name="studentId">The student Id from which you will retrieve the data</param>
        /// <returns>The student of interest</returns>
        [Route("api/Students/GetStudent/{id}")]
        [HttpGet]
        public Student GetStudent(int studentId)
        {
            return _studentDataService.GetSingleStudent(studentId);
        }
    }
}