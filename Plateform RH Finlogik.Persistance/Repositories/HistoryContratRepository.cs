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
    public class HistoryContratRepository : BaseRepository<HistoryContrat>, IHistoryContratRepository
    {
        public HistoryContratRepository(PlateformRHDbcontext dbContext) : base(dbContext)
        {

        }


        public List<HistoryContrat> GetAllHistoryContratByEmployeeID(int id)
        {
            return _dbContext.Set<HistoryContrat>().Include("Contrat").Include("Employee").Where(x => x.IdEmployee == id).ToList();
        }
    }
}
