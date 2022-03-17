using Microsoft.EntityFrameworkCore;
using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Persistance.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PlateformRHDbcontext dbContext) : base(dbContext)
        {
           
        }

        public async Task<Employee> GetUser(string email, string password)
        {
            return await _dbContext.Set<Employee>().Include(u=> u.Role).SingleOrDefaultAsync(u => u.WorkEmail == email && u.Password == password);
        }
    }
}
