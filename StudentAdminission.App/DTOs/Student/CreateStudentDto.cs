using FluentValidation;

namespace StudentAdminission.App.DTOs.Student
{
    public class CreateStudentDto
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IsNumber { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string OriginalFileName { get; set; }
    }

    public class CreateStudentDtoValidator :AbstractValidator<CreateStudentDto> 
    {
        public CreateStudentDtoValidator()
        {
            RuleFor(x => x.FirtName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x=>x.DateOfBirth)
                .NotEmpty();
            RuleFor(x=>x.IsNumber)
                .NotEmpty();
        }
    }
}
