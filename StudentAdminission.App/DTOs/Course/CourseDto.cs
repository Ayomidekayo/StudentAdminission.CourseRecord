using FluentValidation;

namespace StudentAdminission.App.DTOs.Course
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
    }

    public class CourseDtoValidator:AbstractValidator<CourseDto>
    {
        public CourseDtoValidator()
        {
            RuleFor(X=>X.Title)
                .NotEmpty();
            RuleFor(X=>X.Credits)
                .NotEmpty();
        }
    }
}
