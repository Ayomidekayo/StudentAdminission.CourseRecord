namespace StudentAdmission.Data.Contracts
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<Course> GetStudentList(int id);
    }
}
