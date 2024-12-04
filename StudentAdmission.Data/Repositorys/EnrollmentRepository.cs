using StudentAdmission.Data.Contracts;

namespace StudentAdmission.Data.Repositorys
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(StudentAdministionDbContext db) : base(db)
        {
        }
    }
}
