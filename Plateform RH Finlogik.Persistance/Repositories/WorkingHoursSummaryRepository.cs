using Plateform_RH_Finlogik.Application.Contracts.Persistance;
using Plateform_RH_Finlogik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik.Persistance.Repositories
{


    public class WorkingHoursSummaryRepository : BaseRepository<WorkingHoursSummary>, IWorkingHoursSummaryRepository
    {
        public WorkingHoursSummaryRepository(PlateformRHDbcontext dbContext) : base(dbContext)
        {
        }
        public async Task<WorkingHoursSummary> GetWorkingHoursSummaryByIDEmployee_Date(int IDEmployee, DateTime date)
        {
            return _dbContext.WorkingHoursSummarys.Where(x => x.IdEmployee == IDEmployee && x.date.Day == date.Day).FirstOrDefault();

        }
    }
}
