using FluentValidation;
using StudentAdmission.Data.Contracts;
    
namespace StudentAdminission.App.DTOs.Enrollment
{
    public class CreateEntrollmentDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
       
    }
    public class CreateEntrollmentDtoValliator : AbstractValidator<CreateEntrollmentDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;

        public CreateEntrollmentDtoValliator(ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
          
            this._courseRepository = courseRepository;
            this._studentRepository = studentRepository;

            RuleFor(x => x.CourseId)
                .MustAsync(async (id, token) =>
                {
                    var courseExist = await _courseRepository.ExistAsync(id);
                    return courseExist;
                }).WithMessage("{propertyName} does not exist");
            RuleFor(x => x.StudentId)
               .MustAsync(async (id, token) =>
               {
                   var studentExist = await _studentRepository.ExistAsync(id);
                   return studentExist;
               }).WithMessage("{propertyName} does not exist"); 
        }
    }
}
