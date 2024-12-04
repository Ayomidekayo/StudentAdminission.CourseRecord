using FluentValidation;
using StudentAdminission.App.DTOs.Course;
using StudentAdminission.App.DTOs.Student;
using StudentAdmission.Data.Contracts;

namespace StudentAdminission.App.DTOs.Enrollment
{
    public class EntrollmentDto : CreateEntrollmentDto
    {
       
        public virtual StudentDto Student { get; set; }
        public virtual CourseDto Course { get; set; }
    }

    public class EntrollmentDtoVaidaor : AbstractValidator<EntrollmentDto>
    {

        public EntrollmentDtoVaidaor(ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            Include(new CreateEntrollmentDtoValliator(courseRepository, studentRepository));
        }
    }
}
