using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Persistance.Repositories
{
    public class EmployeePayRepository : BaseRepository<EmployeePay>, IEmployeePayRepository
    {
        public EmployeePayRepository(PlateformRHDbcontext dbContext) : base(dbContext)
        {

        }

        public List<EmployeePay> GetHistoryPayOfEmployee(int id)
        {
           return  _dbContext.Set<EmployeePay>().Where(x => x.IdEmployee == id).ToList();
        }
    }
}
