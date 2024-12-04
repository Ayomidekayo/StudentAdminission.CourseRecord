using Microsoft.EntityFrameworkCore;
using StudentAdmission.Data.Contracts;

namespace StudentAdmission.Data.Repositorys
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(StudentAdministionDbContext db) : base(db)
        {
        }

       

        public async Task<Course> GetStudentList(int id)
        {
          var liststudents=  await db.Courses.Include(u=>u.Enrollment).ThenInclude(u=>u.Student)
                .FirstOrDefaultAsync(c => c.Id == id);
            return  liststudents;
        }
    }
}
