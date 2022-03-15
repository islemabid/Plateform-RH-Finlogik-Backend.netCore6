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
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return entity;
            }catch(Exception ex) { return null; }
        }

        public  async Task DeleteAsync(T entity)
        {

           
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            
            
         
        }

        public  async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public  async Task<T> GetByIDAsync(int  ID)
        {
           return await _dbContext.Set<T>().FindAsync(ID);
        }

        public  async Task<T> UpdateAsync( T entity)
        {

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }

        

    }
}
