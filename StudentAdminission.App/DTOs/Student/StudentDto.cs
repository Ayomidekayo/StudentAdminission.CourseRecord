using FluentValidation;
using StudentAdminission.App.DTOs.Course;

namespace StudentAdminission.App.DTOs.Student
{
    public class StudentDto:CreateStudentDto
    {
        public int Id { get; set; }
       
    }

    public class StudentDtoValidator : AbstractValidator<StudentDto>
    {
        public StudentDtoValidator()
        {
            Include(new CreateStudentDtoValidator());
        }

    }
}
