using FluentValidation;

namespace StudentAdminission.App.DTOs.Course
{
    public class CreateCourseDto
    {
      
        public string Title { get; set; }
        public int Credits { get; set; }
    }

    public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseDtoValidator()
        {
            RuleFor(X => X.Title)
                .NotEmpty();
            RuleFor(X => X.Credits)
                .NotEmpty();
        }
    }
}
