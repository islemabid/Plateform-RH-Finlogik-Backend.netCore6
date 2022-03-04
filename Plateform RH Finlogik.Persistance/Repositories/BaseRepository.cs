using Microsoft.EntityFrameworkCore;
using Plateform_RH_Finlogik.Application.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Persistance.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly PlateformRHDbcontext _dbContext;

        public BaseRepository(PlateformRHDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public  async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public  async Task DeleteAsync(long ID)
        {
            var entity = await _dbContext.Set<T>().FindAsync(ID);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public  async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public  async Task<T> GetByIDAsync(long ID)
        {
           return await _dbContext.Set<T>().FindAsync(ID);
        }

        public  async Task<T> UpdateAsync(long ID, T entity)
        {

            T t = await _dbContext.Set<T>().FindAsync(ID);
            _dbContext.Update(t);
            await _dbContext.SaveChangesAsync();
            return t;
        }

        

    }
}
