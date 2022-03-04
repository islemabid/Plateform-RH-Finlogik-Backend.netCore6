using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Application.Persistance
{
    public interface IAsyncRepository<T> where T:class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIDAsync(long ID);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(long ID ,T entity);
        Task DeleteAsync(long ID);

    }
}
