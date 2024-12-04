using FluentValidation;

namespace StudentAdminission.App.DTOs.Authentication
{
    public class RegistrationDto:LogInDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfbirth { get; set; }
    }

    public class RegistrationDtoValidator : AbstractValidator<RegistrationDto>
    {
        public RegistrationDtoValidator()
        {
            Include(new LogInDtoValidator());
            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x=>x.DateOfbirth)
                .Must((dob)=>
                {
                    if (dob.HasValue)
                    {
                        return dob.Value < DateTime.Now;
                    }
                    return true;
                });
                
        }

    }
}
