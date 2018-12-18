namespace ContosoUWebAPI.DAL
{
    using ContosoUWebAPI.Models;
    using System.Collections.Generic;

    /// <summary>
    /// The EnrollmentDataService methods are only created and defined in the interface. 
    /// However, the EnrollmentDataService class will define the implementation of these
    /// methods below.
    /// </summary>
    public interface IEnrollmentDataService
    {
        List<Enrollment> GetAllEnrollments();
        bool InsertEnrollment(Enrollment enrollment);
        bool DeleteEnrollment(int enrollmentId);
        bool UpdateEnrollment(Enrollment enrollment);
        Enrollment GetSingleEnrollment(int enrollmentId); 
    }
}