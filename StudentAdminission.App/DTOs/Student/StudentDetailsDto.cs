using StudentAdminission.App.DTOs.Course;
using StudentAdminission.App.DTOs.Enrollment;

namespace StudentAdminission.App.DTOs.Student
{
    public class StudentDetailsDto : CreateStudentDto
    {
       
        public List<CourseDto> Courses { get; set; }=new List<CourseDto>();

    }
}
