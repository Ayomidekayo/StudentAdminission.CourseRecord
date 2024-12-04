using AutoMapper;
using StudentAdminission.App.DTOs.Course;
using StudentAdminission.App.DTOs.Enrollment;
using StudentAdminission.App.DTOs.Student;
using StudentAdmission.Data;

namespace StudentAdminission.App.Configuration
{
    public class AutoMapperConfigProfile:Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<Course, CourseDetailsDto>().ForMember(u=>u.Students,u=>u.MapFrom(c=>c.Enrollment.Select(stu=>stu.Student)));

            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, StudentDetailsDto>().ForMember(u=>u.Courses ,u=>u.MapFrom(sd=>sd.Enrollment.Select(e=>e.Course)));
            
            CreateMap<Enrollment, EntrollmentDto>().ReverseMap();
            CreateMap<Enrollment, CreateEntrollmentDto>().ReverseMap();

        }
    }
}
