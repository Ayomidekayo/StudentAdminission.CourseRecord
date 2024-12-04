using FluentValidation;

namespace StudentAdminission.App.DTOs.Authentication
{
    public class LogInDto
    {
        public string EmailAdress { get; set; }
        public string Password { get; set; }
    }

    public class LogInDtoValidator :AbstractValidator<LogInDto>
    {
        public LogInDtoValidator()
        {
            RuleFor(x => x.EmailAdress)
                .NotEmpty().
                EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);
        }
    }

}