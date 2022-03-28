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


    }
}
