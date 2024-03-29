﻿

namespace Plateform_RH_Finlogik.Application.Persistance
{
    public interface IAsyncRepository<T> where T:class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIDAsync(int  ID);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}
