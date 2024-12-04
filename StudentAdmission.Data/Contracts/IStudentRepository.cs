namespace StudentAdmission.Data.Contracts
{
    public interface IStudentRepository:IGenericRepository<Student>         
    {
        Task<Student> GetStudentDetails(int id);
    }

    
}
