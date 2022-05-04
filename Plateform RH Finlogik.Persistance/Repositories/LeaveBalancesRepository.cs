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
    public class LeaveBalancesRepository : BaseRepository<LeaveBalance>, ILeaveBalancesRepository
    {
        public LeaveBalancesRepository(PlateformRHDbcontext dbContext) : base(dbContext)
        {
        }

        public async Task<LeaveBalance> GetLeaveBalanceByIDEmployee_IDLeaveType(int IDEmployee, int IDLeaveType)
        {
            return  await _dbContext.Set<LeaveBalance>().Include("LeaveType").Include("Employee").SingleOrDefaultAsync(x => x.IdEmployee == IDEmployee && x.IdLeaveType == IDLeaveType);
        }
    }
}
