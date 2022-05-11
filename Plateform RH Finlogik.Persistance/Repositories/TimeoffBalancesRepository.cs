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
    public class TimeoffBalancesRepository : BaseRepository<TimeOffBalances>, ItimeoffBalancesRepository
    {
        public TimeoffBalancesRepository(PlateformRHDbcontext dbContext) : base(dbContext)
        {

        }
        public async Task<List<TimeOffBalances>> GetallTimeOffBalancesOfEmployee(int id)
        {

            var alltimeoffbalances = await _dbContext.TimeOffBalances.Include("LeaveType").Where(x => x.IdEmployee == id).ToListAsync();

            return alltimeoffbalances;

        }
        public async Task<List<TimeOffBalances>> Getall()
        {

            var alltimeoffbalances = await _dbContext.TimeOffBalances.Include("LeaveType").ToListAsync();

            return alltimeoffbalances;

        }


    }
}
