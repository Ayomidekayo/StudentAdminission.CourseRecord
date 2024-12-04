using Microsoft.EntityFrameworkCore;
using StudentAdmission.Data.Contracts;

namespace StudentAdmission.Data.Repositorys
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentAdministionDbContext db) : base(db)
        {
        }

        public async Task<Student> GetStudentDetails(int id)
        {
          var students=await  db.Students
                .Include(u=>u.Enrollment).ThenInclude(u=>u.Course)

                .FirstOrDefaultAsync(x => x.Id == id);
            return students;
               
        }
    }
}
