using Microsoft.EntityFrameworkCore;
using StudentAdmission.Data.Contracts;

namespace StudentAdmission.Data.Repositorys
{
    public class GenericRepository<TEnity> : IGenericRepository<TEnity> where TEnity : BaseEntity
    {
        protected readonly StudentAdministionDbContext db;

        public GenericRepository(StudentAdministionDbContext db)
        {
            this.db = db;
        }
        public async Task<TEnity> AddAsync(TEnity model)
        {
            await db.AddAsync(model);
            await db.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var model = await GetByIdAsync(id);
            db.Set<TEnity>().Remove(model);
          return  await db.SaveChangesAsync() >0;
        }

        public async Task<bool> ExistAsync(int id)
        {
            //await GetByIdAsync(id);
           return  await db.Set<TEnity>().AnyAsync(u=>u.Id == id);  //return true;
        }

        public async Task<IEnumerable<TEnity>> GetAllAsyn()
        {
           return   await db.Set<TEnity>().ToListAsync();
        }

        public async Task<TEnity> GetByIdAsync(int? id)
        {
          return  await db.Set<TEnity>().FindAsync(id);
        }

        public Task<TEnity> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEnity model)
        {
           db.Update(model);
            await db.SaveChangesAsync();
        }
    }
}
