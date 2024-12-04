namespace StudentAdmission.Data.Contracts
{
    public interface IGenericRepository<TEnity> where TEnity : BaseEntity
    {
        Task<IEnumerable<TEnity>> GetAllAsyn(); 
        Task<TEnity> GetByIdAsync(int? id);
        Task<TEnity> GetByNameAsync(string name);
        
        Task<TEnity> AddAsync(TEnity model);
        Task UpdateAsync(TEnity model);
        Task<bool> DeleteAsync(int id);
       Task<bool> ExistAsync(int id);
    }
}
